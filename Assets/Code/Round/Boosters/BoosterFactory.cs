using UnityEngine;

public class BoosterFactory : IBoosterFactory
{
	private readonly ISceneManager _sceneManager;

	public BoosterFactory(
				ISceneManager sceneManager)
	{
		_sceneManager = sceneManager;
	}

	public IBoosterView CreateBooster(string path, Transform parent)
	{
		return _sceneManager.InstantiateObject(path, parent).GetComponent<IBoosterView>();
	}
}