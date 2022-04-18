using System;

public interface IDirtyContainer : IDisposable
{
	T Resolve<T>();
	void Use<T>(T obj);
	bool TryGetUsing(Type type, out object use);
}
