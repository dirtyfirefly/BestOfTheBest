using UnityEngine;

public class LevelsMenuController : ControllerBase
{
	public class Parameters
	{
		public readonly Transform Placeholder;

		public Parameters(Transform placeholder)
		{
			Placeholder = placeholder;
		}
	}

	private readonly ISceneManager _sceneManager;
	private readonly IMainCanvasePathResolver _pathResolver;
	private readonly Parameters _parameters;
	private readonly IMaunMenuEventAggregator _eventAggregator;

	private GameObject _levels;
	private ILevelsMenuView _levelsView;

	public LevelsMenuController(
		ISceneManager sceneManager,
		IMainCanvasePathResolver pathResolver,
		Parameters parameters,
		IMaunMenuEventAggregator eventAggregator)
	{
		_sceneManager = sceneManager;
		_parameters = parameters;
		_pathResolver = pathResolver;
		_eventAggregator = eventAggregator;
	}

	public override void OnStart()
	{
		_levels = _sceneManager.InstantiateObject(_pathResolver.GetLevelsPanelPath(), _parameters.Placeholder);
		_levelsView = _levels.GetComponent<ILevelsMenuView>();

		_eventAggregator.LevelsPanelClicked.AddListener(_levelsView.ShowPanel);
	}

	public override void OnStop()
	{
	}

	//private void LoadLevel(int levelNumber)
	//{
	//	_levelLoader.LoadLevel(levelNumber);
	//	_eventAggregator.LevelOpend.Invoke();
	//}
}
