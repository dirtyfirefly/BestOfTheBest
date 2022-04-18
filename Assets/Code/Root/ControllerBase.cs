using System;
using System.Collections.Generic;

public abstract class ControllerBase : IDisposable
{
    private List<ControllerBase> _children;

    public ControllerBase()
    {
        _children = new List<ControllerBase>();
    }

    public abstract void OnStart();

    public abstract void OnStop();

    public void Start()
    {
        OnStart();
    }

    public void Stop()
    {
        foreach (var child in _children)
        {
            child.Stop();
        }

        OnStop();
    }

    public virtual void Dispose()
    {
        foreach (var child in _children)
        {
            _children.Remove(child);
            child.Dispose();
        }

        _children.Clear();
    }

    public void AddController(ControllerBase controller)
    {
        _children.Add(controller);
        controller.Start();
    }

    public void RemoveController(ControllerBase controller)
    {
        controller.Stop();
        controller.Dispose();
        _children.Remove(controller);
    }
}
