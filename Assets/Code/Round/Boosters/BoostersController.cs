public class BoostersController : ControllerBase
{
	public class Parameters
	{
		public BlockViewBase[] Tiles { get; private set; }

		public Parameters(BlockViewBase[] tiles)
		{
			Tiles = tiles;
		}
	}

	private readonly IRoundEventAggregator _roundEventAggregator;
	private readonly IBoosterFactory _boosterFactory;
	private readonly BlockViewBase[] _tiles;

	private IBoosterView[] _boosterViews;

	public BoostersController(
		IRoundEventAggregator roundEventAggregator,
		IBoosterFactory boosterFactory,
		Parameters parameters)
	{
		// add player setting !!!
		_tiles = parameters.Tiles;
		_roundEventAggregator = roundEventAggregator;
		_boosterFactory = boosterFactory;
	}

	public override void OnStart()
	{
		CreateBoosters();
	}

	public override void OnStop()
	{
	}

	private void CreateBoosters() //int amount // use player setting
	{
		_boosterViews = new IBoosterView[1]; // use amount

		for (int i = 0; i < 0; i++) // use player setting
		{
			var path = ""; // create method(random) and use pathResolver
			var parent = _tiles[0].transform; // create method for random unicum tile
			_boosterViews[i] = _boosterFactory.CreateBooster(path, parent);
		}
	}
}
