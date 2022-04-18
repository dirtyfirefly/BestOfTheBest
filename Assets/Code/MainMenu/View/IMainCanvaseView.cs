using UnityEngine;
using UnityEngine.Events;

public interface IMainCanvaseView
{
	Transform LevelsPlaceholder { get; }
	UnityEvent LevelsButtonClicked { get; }

	void SetCamera(Camera camera);
	void ToGameMenu();
	void ToLobbyMenu();
}
