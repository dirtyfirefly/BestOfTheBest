public class CameraModule : IModule
{
	public void Registrations(DirtyBuilder builder)
	{
		builder.Register<ICameraPathResolver, CameraPathResolver>();
		builder.Register<ICameraPositionsResolver, CameraPositionsResolver>();

		builder.RegisterController<CameraController>().SingleInstance();
	}
}
