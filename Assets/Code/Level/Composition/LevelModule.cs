public class LevelModule : IModule
{
	public void Registrations(DirtyBuilder builder)
	{
		builder.Register<ILevelLoader, LevelLoader>().SingleInstance();
	}
}
