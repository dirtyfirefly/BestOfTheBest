public class RegistrationData : IRegistrationData
{
	public SingletonStates SingletonState { get; private set; }
	public ExternallyStates ExternallyState { get; private set; }
	public bool IsDisposible { get; private set; }

	public RegistrationData()
	{
		SingletonState = SingletonStates.Default;
		ExternallyState = ExternallyStates.Default;
		IsDisposible = false;
	}

	public RegistrationData SingleInstance()
	{
		SingletonState = SingletonStates.Singleton;
		IsDisposible = false;
		return this;
	}

	public RegistrationData ExternallyOwneed()
	{
		ExternallyState = ExternallyStates.Externally;
		IsDisposible = false;
		return this;
	}

	public RegistrationData MarkAsDisposable()
	{
		IsDisposible = true;
		return this;
	}
}
