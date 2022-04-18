using UnityEngine;

public interface IResourceLoader
{
    GameObject LoadResource(string path);
	void LoadPrefabs();
	ListItemInfo LoadLevelInfo(string path);

	GameObject GetLevelBaseClone();
	GameObject GetForestBridleLitleClone();
	GameObject GetForestGrasEmptyClone();
	GameObject GetForestGroundEmptyClone();
} 
