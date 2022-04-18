using System;
using System.Reflection;

public class RegistrationComponent : IRegistrationComponent
{
	private readonly IRegistrationData _data;
	private readonly Type _type;

	private Func<object> _creator;

	public RegistrationComponent(IRegistrationData data, Type type)
	{
		_data = data;
		_type = type;
	}

	public bool IsDisposable => _data.IsDisposible;
	public bool IsSingleton => _data.SingletonState == SingletonStates.Singleton;
	public bool IsExtrnally => _data.ExternallyState == ExternallyStates.Externally;

	public object CreateWithMaximumParameters(IDirtyContainer container)
	{
		if (_creator == null)
		{
			var (parameters, ctor) = GetTypeParameterFromCtors();
			var dependencies = GetDependencies(parameters, container);
			_creator = () => ctor.Invoke(dependencies);
		}

		return _creator();
	}

	private (ParameterInfo[], ConstructorInfo) GetTypeParameterFromCtors()
	{
		var indexCtorWithMaxParameters = 0;
		var ctors = _type.GetConstructors();

		for (var i = 1; i < ctors.Length; i++)
		{
			if (ctors[indexCtorWithMaxParameters].GetParameters().Length < ctors[i].GetParameters().Length)
			{
				indexCtorWithMaxParameters = i;
			}
		}

		var ctor = ctors[indexCtorWithMaxParameters];
		var parameters = ctor.GetParameters();

		return (parameters, ctor);
	}

	private object[] GetDependencies(ParameterInfo[] parameters, IDirtyContainer container)
	{
		if (parameters.Length == 0)
		{
			return null;
		}

		var dependacies = new object[parameters.Length];

		for (var i = 0; i < parameters.Length; i++)
		{
			var parameterType = parameters[i].ParameterType;

			if (container.TryGetUsing(parameterType, out var obj))
			{
				dependacies[i] = obj;
			}
			else
			{
				dependacies[i] = typeof(DirtyContainer).GetMethod("Resolve").MakeGenericMethod(parameterType).Invoke(container, null);
			}
		}

		return dependacies;
	}
}
