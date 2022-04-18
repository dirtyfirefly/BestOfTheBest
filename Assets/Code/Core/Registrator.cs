public class Registrator
{
	public static DirtyBuilder _builder;

	public Registrator()
	{
		_builder = new DirtyBuilder();
	}

	public IDirtyContainer CreateContainer()
	{
		new CoreModule().Registrations(_builder);
		new RootModule().Registrations(_builder);
		new CameraModule().Registrations(_builder);
		new LevelModule().Registrations(_builder);
		new CanvaseModule().Registrations(_builder);
		new RoundModule().Registrations(_builder);

		var container = _builder.Create();
		return container;
	}
}
