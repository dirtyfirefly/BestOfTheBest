using System;
using System.Collections.Generic;
using System.Linq;

public class DirtyBuilder
{
	private readonly IDictionary<string, Lazy<IRegistrationComponent>> _registrations;
	private readonly IDictionary<string, object> _singletonRegistrations;

	public DirtyBuilder()
	{
		_registrations = new Dictionary<string, Lazy<IRegistrationComponent>>();
		_singletonRegistrations = new Dictionary<string, object>();
	}

	public IRegistrationData RegisterController<TClass>()
	{
		return Register<TClass, TClass>();
	}

	public IRegistrationData RegisterControllerWithParameters<TClass, TParameters>()
	{
		Register<TParameters, TParameters>();
		return Register<TClass, TClass>().ExternallyOwneed();
	}

	public IRegistrationData Register<TInterface, TClass>()
	{
		var type = typeof(TInterface);
		var data = new RegistrationData();
		if (IsDisposable(type))
		{
			data.MarkAsDisposable();
		}

		var nameKey = type.FullName;
		var conponent = new Lazy<IRegistrationComponent>(() => new RegistrationComponent(data, typeof(TClass)));
		_registrations.Add(nameKey, conponent);

		return data;
	}

	public IDirtyContainer Create()
	{
		return new DirtyContainer(_registrations, _singletonRegistrations);
	}

	private bool IsDisposable(Type type)
	{
		var interfaces = type.GetInterfaces();
		var expected = typeof(IDisposable).FullName;

		return interfaces.Any(i => i.Equals(expected));
	}
}
