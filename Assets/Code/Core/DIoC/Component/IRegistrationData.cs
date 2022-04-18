public interface IRegistrationData
{
	SingletonStates SingletonState { get; }
	ExternallyStates ExternallyState { get; }
	bool IsDisposible { get; }

	RegistrationData SingleInstance();
	RegistrationData ExternallyOwneed();
	RegistrationData MarkAsDisposable();
}
