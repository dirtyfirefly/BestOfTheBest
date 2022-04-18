public interface IControllerFactory
{
	void SetContainer(IDirtyContainer container);
	T CrateController<T>();
	T CrateControllerWithParameters<T, P>(P parametesrs);
}
