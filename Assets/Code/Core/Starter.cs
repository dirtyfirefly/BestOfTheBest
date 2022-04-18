using UnityEngine;

public class Starter : MonoBehaviour
{
	private ControllerBase _rootController;
	private IDirtyContainer _container;

    private void Start()
    {
		var register = new Registrator();

		_container = register.CreateContainer();
		var contrllerFactory = _container.Resolve<IControllerFactory>();
		contrllerFactory.SetContainer(_container);

		var rootController = _container.Resolve<RootController>();
		rootController.Start();
    }

	private void OnDestroy()
	{
		_rootController?.Dispose();
		_container?.Dispose();
	}
}
