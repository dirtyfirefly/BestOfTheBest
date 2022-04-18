public class RootController : ControllerBase
{
    private readonly IControllerFactory _controllerFactory;

    public RootController(
		IControllerFactory controllerFactory)
    {
		_controllerFactory = controllerFactory;
    }

    public override void OnStart()
    {
        CreateCameraController();
		CreateMainCanvase();
		CreateRoundController();
	}

    public override void OnStop()
    {
    }

    private void CreateCameraController()
    {
		var controller = _controllerFactory.CrateController<CameraController>();
		AddController(controller);
	}

	private void CreateMainCanvase()
	{
		var controller = _controllerFactory.CrateController<MainCanvaseController>();
		AddController(controller);
	}

	private void CreateRoundController()
	{
		var controller = _controllerFactory.CrateController<RoundController>();
		AddController(controller);
	}
}
