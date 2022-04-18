using UnityEngine;

public class CameraController : ControllerBase
{
    private readonly ISceneManager _sceneManager;
    private readonly ICameraPathResolver _pathResolver;
    private readonly ICameraPositionsResolver _cameraPositionManager;

    private GameObject _cameraObject;
    private ICameraView _cameraView;

    public CameraController(
		ISceneManager sceneManager,
		ICameraPositionsResolver cameraPositionManager,
		ICameraPathResolver pathResolver)
    {
        _sceneManager = sceneManager;
        _cameraPositionManager = cameraPositionManager;
        _pathResolver = pathResolver;
    }

    public override void OnStart()
    {
        _cameraObject = _sceneManager.InstantiateObject(_pathResolver.GetCameraPath());
        _cameraView = _cameraObject.GetComponent<ICameraView>();
    }

    public override void OnStop()
    {
        _cameraView = null;
        _sceneManager.DestroyObject(_cameraObject);
    }
}
