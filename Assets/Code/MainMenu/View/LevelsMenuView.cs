using UnityEngine;
using UnityEngine.Events;

public class LevelsMenuView : MonoBehaviour, ILevelsMenuView
{
	public UnityEvent<int> LevelButtonClicked { get; private set; } = new UnityEvent<int>();

	public void OnButtonCLick(int levelNumber)
	{
		LevelButtonClicked.Invoke(levelNumber);
	}

	public void ShowPanel()
	{
		gameObject.SetActive(true);
	}
}
