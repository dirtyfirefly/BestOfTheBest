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

	public void ToGameMenu()
	{
		gameObject.SetActive(false);
		// hide lobby menu
		// show game menu
	}

	public void ToLobbyMenu()
	{
		// hide game menu
		// show lobby menu
	}

	public void OnLevelsButtonClicked()
	{
		LevelsButtonClicked.Invoke();
	}
}
