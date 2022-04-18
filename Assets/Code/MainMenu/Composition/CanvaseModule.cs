public class CanvaseModule : IModule
{
	public void Registrations(DirtyBuilder builder)
	{
		builder.RegisterController<MainCanvaseController>().SingleInstance();
		builder.RegisterControllerWithParameters<LevelsMenuController, LevelsMenuController.Parameters>();

		builder.Register<IMainCanvasePathResolver, MainCanvasePathResolver>();
		builder.Register<IMaunMenuEventAggregator, MaunMenuEventAggregator>().SingleInstance();
	}
}
