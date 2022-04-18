public class RoundModule : IModule
{
	public void Registrations(DirtyBuilder builder)
	{
		builder.RegisterController<RoundController>().SingleInstance();
		builder.RegisterController<MapController>().SingleInstance();
		builder.RegisterController<BoostersController>().SingleInstance();

		builder.Register<IRoundEventAggregator, RoundEventAggregator>().SingleInstance();
	}
}