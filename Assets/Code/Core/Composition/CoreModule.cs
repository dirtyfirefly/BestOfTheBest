public class CoreModule : IModule
{
	public void Registrations(DirtyBuilder builder)
	{
		builder.Register<IResourceLoader, ResourceLoader>().SingleInstance();
		builder.Register<ISceneManager, SceneManager>().SingleInstance();
		builder.Register<IPathResolverBase, PathResolverBase>().SingleInstance();
	}
}
