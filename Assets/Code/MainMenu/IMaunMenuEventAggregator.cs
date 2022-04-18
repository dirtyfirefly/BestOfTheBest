using UnityEngine.Events;

public interface IMaunMenuEventAggregator
{
	UnityEvent LevelClicked { get; }
	UnityEvent LevelsPanelClicked { get; }
}
