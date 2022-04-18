public class RootModule : IModule
{
	public void Registrations(DirtyBuilder builder)
	{
		builder.RegisterController<RootController>().SingleInstance();
		builder.Register<IControllerFactory, ControllerFactory>().SingleInstance();
	}
}
