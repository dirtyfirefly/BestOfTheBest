using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class LevelViewSaver : MonoBehaviour
{
	private ListItemInfo _listItems;

	public string LevelNumber;
	// for level disigner
	public string Version;
	public string NameForTemplateFolder;

	public void SaveLevel()
	{
		CreateLevelInfo();
		XmlSerializer formatter = new XmlSerializer(typeof(ListItemInfo));

		var folderName = string.IsNullOrEmpty(NameForTemplateFolder)
			? ""
			: $"/{NameForTemplateFolder}";
		var path = $"{Application.streamingAssetsPath}/Level{LevelNumber}{Version}.xml"; // LevelsData{folderName}/
		using (FileStream fs = new FileStream(path, FileMode.Create))
		{
			formatter.Serialize(fs, _listItems);
		}
	}

	private void CreateLevelInfo()
	{
		_listItems = new ListItemInfo();
		for (int i = 0; i < transform.childCount; i++)
		{
			var tmp = transform.GetChild(i);
			var view = tmp.GetComponent<BlockViewBase>();

			var itemInfo = new ItemInfo(tmp.position.x, tmp.position.y, tmp.position.z,
											tmp.rotation.x, tmp.rotation.y, tmp.rotation.z, tmp.rotation.w,
											tmp.localScale.x, tmp.localScale.y, tmp.localScale.z,
											tmp.tag);

			if (view != null)
			{
				itemInfo.Name = view.Name;
				itemInfo.NUMBER = view.NUMBER;
				itemInfo.PreviousNumber = view.PreviousNumber;
				itemInfo.NextNumber = view.NextNumber;
				itemInfo.IsTriger = view.IsTriger;
				itemInfo.TargetNames = view.TargetNames;
				itemInfo.DifferentlyNextNumber = view.DifferentlyNextNumber;
				itemInfo.DifferentlyPreviousNumber = view.DifferentlyPreviousNumber;
			}

			_listItems.lvlInfo.Add(itemInfo);
		}
	}
}