using System.Linq;
using UnityEngine;

public class MapController : ControllerBase
{
	private readonly ILevelLoader _levelLoader;
	private readonly IRoundEventAggregator _roundEventAggregator;
	private readonly IMaunMenuEventAggregator _menuEventAggregator;
	private readonly ISceneManager _sceneManager;
	private readonly IControllerFactory _controllerFactory;

	private GameObject _currentLevel;
	private BlockViewBase[] _tiles;

	public MapController(
		ILevelLoader levelLoader,
		IRoundEventAggregator roundEventAggregator,
		IMaunMenuEventAggregator menuEventAggregator,
		ISceneManager sceneManager,
		IControllerFactory controllerFactory)
	{
		_levelLoader = levelLoader;
		_roundEventAggregator = roundEventAggregator;
		_menuEventAggregator = menuEventAggregator;
		_sceneManager = sceneManager;
		_controllerFactory = controllerFactory;
	}

	public override void OnStart()
	{
		_roundEventAggregator.LevelOpend.AddListener(LoadLevel);
	}

	public override void OnStop()
	{
		if (_currentLevel != null)
		{
			_tiles = null;
			DestroyLevel();
		}
	}

	private void LoadLevel(int levelNumber)
	{
		_currentLevel = _levelLoader.LoadLevel(levelNumber);
		
		FindTilesOnMap();
	}

	private void CreateBoostersController()
	{
		var parameters = new BoostersController.Parameters(_tiles);
		var controller = _controllerFactory.CrateControllerWithParameters<BoostersController, BoostersController.Parameters>(parameters);
	}

	private void DestroyLevel()
	{
		_sceneManager.DestroyObject(_currentLevel);
	}

	private void FindTilesOnMap()
	{
		_tiles = _sceneManager.FindObjectsOnScene<BlockViewBase>();
		_tiles.OrderBy(x => x.NUMBER);
	}

	private void CheckPathFinalTileFree(Vector3 nextChipPosition, Vector3[] chipsPosition)
	{
		var isFree = chipsPosition.Any(x => x.EquilsVectors(nextChipPosition));
		// add event to round aggregator and sare
	}

	private void CalculateChipPath(Vector3 chipPosition, int stepsCount)
	{
		var chipTile = _tiles.Where(x => x.GetCentralPosition().EquilsVectors(chipPosition)).ToList();
		var indexChipTile = _tiles.ToList().IndexOf(chipTile[0]);

		var finish = stepsCount >= _tiles.Length - 1 ? _tiles.Length : indexChipTile + stepsCount;
		var finalStepsCount = finish - indexChipTile;

		var tilesPosition = new Vector3[finalStepsCount];
		for (int i = indexChipTile + 1, j = 0; i <= finish; i++, j++)
		{
			tilesPosition[j] = _tiles[i].GetCentralPosition();
		}
		// add event to round aggregator and share array with event
		//return tilesPosition;
	}
}
