using System;
using UnityEngine;

public class SceneManager : ISceneManager
{
    private readonly IResourceLoader _resourceLoader;

    public ICustomCoroutine Coroutiner { get; private set; }
    
    public SceneManager(IResourceLoader resourceLoader)
    {
        _resourceLoader = resourceLoader;

        Coroutiner = FindObjectOnScene<CustomCoroutine>();
    }

    public GameObject InstantiateObject(string path, Transform parent = null)
    {
        var prefab = _resourceLoader.LoadResource(path);
        
        if (parent == null)
        {
            return UnityEngine.Object.Instantiate(prefab);
        }
        else
        {
            return UnityEngine.Object.Instantiate(prefab, parent);
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
		UnityEngine.Object.Destroy(gameObject);
    }

	public T FindObjectOnScene<T>() where T : UnityEngine.Object
	{
		return UnityEngine.Object.FindObjectOfType<T>();
	}

	public T[] FindObjectsOnScene<T>() where T : UnityEngine.Object
	{
		return UnityEngine.Object.FindObjectsOfType<T>();
	}
}
