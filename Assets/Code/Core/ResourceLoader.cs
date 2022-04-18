using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Networking;

public class ResourceLoader : IResourceLoader
{
	private readonly IPathResolverBase _pathResolver;

	private GameObject _forestBridgeLitle;
	private GameObject _forestGrasEmpty;
	private GameObject _forestGroundEmpty;

	private GameObject _levelBase;

	public ResourceLoader(IPathResolverBase pathResolver)
	{
		_pathResolver = pathResolver;
	}

    public GameObject LoadResource(string path)
    {
        return Resources.Load<GameObject>(path);
    }

	public ListItemInfo LoadLevelInfo(string path)
	{
		DownloadFile(path);

		var listItems = new ListItemInfo();
		if (File.Exists($"{Application.persistentDataPath}/{path}"))
		{
			XmlSerializer formatter = new XmlSerializer(typeof(ListItemInfo));

			using (FileStream fs = new FileStream($"{Application.persistentDataPath}/{path}", FileMode.OpenOrCreate))
			{
				fs.Seek(0, SeekOrigin.Begin);
				listItems = (ListItemInfo)formatter.Deserialize(fs);
			}
		}
		return listItems;
	}

	public void LoadPrefabs()
	{
		_levelBase = Resources.Load<GameObject>(_pathResolver.GetLevelBasePath());

		_forestBridgeLitle = Resources.Load<GameObject>(_pathResolver.GetForestBridleLitlePath());
		_forestGrasEmpty = Resources.Load<GameObject>(_pathResolver.GetForestGrasEmptyPath());
		_forestGroundEmpty = Resources.Load<GameObject>(_pathResolver.GetForestGroundEmptyPath());
	}

	public GameObject GetLevelBaseClone()
	{
		return Object.Instantiate(_levelBase);
	}

	public GameObject GetForestBridleLitleClone()
	{
		return Object.Instantiate(_forestBridgeLitle);
	}

	public GameObject GetForestGrasEmptyClone()
	{
		return Object.Instantiate(_forestGrasEmpty);
	}

	public GameObject GetForestGroundEmptyClone()
	{
		return Object.Instantiate(_forestGroundEmpty);
	}

	private void DownloadFile(string path)
	{
		var loadingRequest = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, path));
		loadingRequest.SendWebRequest();
		while (!loadingRequest.isDone)
		{
			if (loadingRequest.isNetworkError || loadingRequest.isHttpError)
			{
				break;
			}
		}

		if (loadingRequest.isNetworkError || loadingRequest.isHttpError)
		{

		}
		else
		{
			File.WriteAllBytes(Path.Combine(Application.persistentDataPath, path), loadingRequest.downloadHandler.data);
		}
	}
}
