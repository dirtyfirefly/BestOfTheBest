using UnityEngine;

public class BoosterView : MonoBehaviour, IBoosterView
{
	public BoosterTypes Type;
	public int StepCount;
	public int IndexNextTile;

	void Start()
	{
	}

	public bool IsActive { get; set; }

	public void Show()
	{
		transform.gameObject.SetActive(true);
	}

	public void Hide()
	{
		transform.gameObject.SetActive(false);
	}
}
