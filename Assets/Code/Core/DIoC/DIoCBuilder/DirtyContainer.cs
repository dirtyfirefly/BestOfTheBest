using System;
using System.Collections.Generic;

public class DirtyContainer : IDirtyContainer
{
	private readonly IDictionary<string, Lazy<IRegistrationComponent>> _registrations;
	private readonly IDictionary<string, object> _singletonRegistrations;
	private readonly IList<object> _objects;
	private readonly IList<IDisposable> _disposablesObjects;
	private readonly IDictionary<string, object> _use;

	public DirtyContainer(
		IDictionary<string, Lazy<IRegistrationComponent>> registrations,
		IDictionary<string, object> singletonRegistrations)
	{
		_registrations = registrations;
		_singletonRegistrations = singletonRegistrations;
		_objects = new List<object>();
		_disposablesObjects = new List<IDisposable>();
		_use = new Dictionary<string, object>();
	}

	public T Resolve<T>()
	{
		var key = typeof(T).FullName;

		if (_singletonRegistrations.ContainsKey(key))
		{
			return (T)_singletonRegistrations[key];
		}

		if (_registrations.ContainsKey(key))
		{
			var component = _registrations[key].Value;
			var obj = component.CreateWithMaximumParameters(this);

			ToAppropriateList(component, obj, key);
			return (T) obj;
		}

		if (_use.ContainsKey(key))
		{
			return (T)_use[key];
		}

		throw new Exception($"Key not registered: {key}");
	}

	public void Use<T>(T obj)
	{
		_use.Add(typeof(T).FullName, obj);
	}

	public bool TryGetUsing(Type type, out object use)
	{
		var key = type.FullName;
		if (_use.ContainsKey(key))
		{
			use = _use[key];
			return true;
		}

		use = null;
		return false;
	}

	public void Dispose()
	{
		foreach(var obj in _disposablesObjects)
		{
			obj.Dispose();
		}
	}

	private void ToAppropriateList(IRegistrationComponent component, object obj, string key)
	{
		if (!component.IsSingleton && !component.IsExtrnally && !component.IsDisposable)
		{
			_objects.Add(obj);
		}
		else if (component.IsSingleton)
		{
			_singletonRegistrations.Add(key, obj);
		}
		else if (component.IsDisposable)
		{
			_disposablesObjects.Add((IDisposable)obj);
		}
	}
}
