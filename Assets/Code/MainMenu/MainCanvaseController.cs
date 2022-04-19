using UnityEngine;

public class MainCanvaseController : ControllerBase
{
	private readonly ISceneManager _sceneManager;
	private readonly IMainCanvasePathResolver _pathResolver;
	private readonly IControllerFactory _controllerFactory;
	private readonly IMaunMenuEventAggregator _menuEventAggregator;
	private readonly IRoundEventAggregator _roundEventAggregator;

	private GameObject _canvase;
	private IMainCanvaseView _canvaseView;

	public MainCanvaseController(
		ISceneManager sceneManager,
		IMainCanvasePathResolver pathResolver,
		IControllerFactory controllerFactory,
		IMaunMenuEventAggregator menuEventAggregator,
		IRoundEventAggregator roundEventAggregator)
	{
		_sceneManager = sceneManager;
		_pathResolver = pathResolver;
		_controllerFactory = controllerFactory;
		_menuEventAggregator = menuEventAggregator;
		_roundEventAggregator = roundEventAggregator;
	}

	public override void OnStart()
	{
		_canvase = _sceneManager.InstantiateObject(_pathResolver.GetMainCanvasePath());
		_canvaseView = _canvase.GetComponent<IMainCanvaseView>();

		var camera = _sceneManager.FindObjectOnScene<Camera>();
		_canvaseView.SetCamera(camera);

		_canvaseView.LevelsButtonClicked.AddListener(OnLevelsButtonClicked);
	}

	public override void OnStop()
	{
		_canvaseView = null;
		_sceneManager.DestroyObject(_canvase);
	}

	private void OnLevelsButtonClicked()
	{
		_roundEventAggregator.LevelOpend.Invoke(0); // add random when we make more levels
		Debug.Log("Yeah!");
	}
}
