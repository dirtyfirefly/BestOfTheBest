using UnityEngine.Events;

public interface ILevelsMenuView
{
	UnityEvent<int> LevelButtonClicked { get; }

	void OnButtonCLick(int levelNumber);
	void ShowPanel();
}
