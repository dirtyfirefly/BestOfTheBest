public class ControllerFactory : IControllerFactory
{
	private IDirtyContainer _container;

	public void SetContainer(IDirtyContainer container)
	{
		_container = container;
	}

	public T CrateController<T>()
	{
		return _container.Resolve<T>();
	}

	public T CrateControllerWithParameters<T, P>(P parametesrs)
	{
		_container.Use(parametesrs);
		return _container.Resolve<T>();
	}
}
