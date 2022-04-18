public class RoundController : ControllerBase
{
	private readonly IControllerFactory _controllerFactory;

	public RoundController(
		IControllerFactory controllerFactory)
	{
		_controllerFactory = controllerFactory;
	}

	public override void OnStart()
	{
		CreateMapController();
	}

	public override void OnStop()
	{
	}

	private void CreateMapController()
	{
		var controller = _controllerFactory.CrateController<MapController>();
		AddController(controller);
	}
}