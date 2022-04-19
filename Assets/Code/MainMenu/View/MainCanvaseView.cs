using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainCanvaseView : MonoBehaviour, IMainCanvaseView
{
	private Button _levelsButton;

	public Transform LevelsPlaceholder => transform;
	public UnityEvent LevelsButtonClicked { get; private set; } = new UnityEvent();

	public void SetCamera(Camera camera)
	{
		var canvase = GetComponent<Canvas>();
		canvase.worldCamera = camera;
	}

	public void OnLevelsButtonClicked()
	{
		LevelsButtonClicked.Invoke();
	}
}
