using UnityEngine;

public interface ISceneManager
{
    ICustomCoroutine Coroutiner { get; }

    GameObject InstantiateObject(string path, Transform parent = null);
    void DestroyObject(GameObject gameObject);
	T FindObjectOnScene<T>() where T : Object;
	T[] FindObjectsOnScene<T>() where T : Object;
}
