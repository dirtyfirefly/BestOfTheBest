using UnityEngine.Events;

public interface IRoundEventAggregator
{
	UnityEvent<int> LevelOpend { get; }
}