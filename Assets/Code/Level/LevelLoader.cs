using UnityEngine;

public class LevelLoader : ILevelLoader
{
	private readonly IResourceLoader _resourceLoader;

	public LevelLoader(IResourceLoader resourceLoader)
	{
		_resourceLoader = resourceLoader;

		_resourceLoader.LoadPrefabs();
	}

	public GameObject LoadLevel(int numberLevel)
	{
		var levelBase = _resourceLoader.GetLevelBaseClone();
		var info = _resourceLoader.LoadLevelInfo($"Level{numberLevel}.xml");

		foreach (ItemInfo item in info.lvlInfo)
		{
			var gameObject = GetClone(item);
			var view = gameObject.GetComponent<BlockViewBase>();

			if (gameObject != null)
			{
				gameObject.transform.SetParent(levelBase.transform);

				gameObject.transform.position = new Vector3(item.PositionX, item.PositionY, item.PositionZ);
				gameObject.transform.rotation = new Quaternion(item.RotateX, item.RotateY, item.RotateZ, item.RotateW);
				gameObject.transform.localScale = new Vector3(item.ScaleX, item.ScaleY, item.ScaleZ);

				if (view != null)
				{
					view.Name = item.Name;
					view.NUMBER = item.NUMBER;
					view.PreviousNumber = item.PreviousNumber;
					view.NextNumber = item.NextNumber;
					view.IsTriger = item.IsTriger;
					view.TargetNames = item.TargetNames;
					view.DifferentlyNextNumber = item.DifferentlyNextNumber;
					view.DifferentlyPreviousNumber = item.DifferentlyPreviousNumber;
				}
			}
		}

		return levelBase;
	}

	private GameObject GetClone(ItemInfo item)
	{
		if (item.Tag == "ForestBridgeLitle")
		{
			return _resourceLoader.GetForestBridleLitleClone();
		}
		else if (item.Tag == "ForestGrasEmpty")
		{
			return _resourceLoader.GetForestGrasEmptyClone();
		}
		else if (item.Tag == "ForestGroundEmpty")
		{
			return _resourceLoader.GetForestGroundEmptyClone();
		}

		return null;
	}
}
