public interface IRegistrationComponent
{
	bool IsDisposable { get; }
	bool IsSingleton { get; }
	bool IsExtrnally { get; }

	object CreateWithMaximumParameters(IDirtyContainer container);
}
