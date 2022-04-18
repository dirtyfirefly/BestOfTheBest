using UnityEngine.Events;

public class MaunMenuEventAggregator : IMaunMenuEventAggregator
{
	public MaunMenuEventAggregator()
	{
		LevelClicked = new UnityEvent();
		LevelsPanelClicked = new UnityEvent();
	}

	public UnityEvent LevelClicked { get; private set; }
	public UnityEvent LevelsPanelClicked { get; private set; }
}
