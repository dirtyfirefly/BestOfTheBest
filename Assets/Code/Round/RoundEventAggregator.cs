using UnityEngine.Events;

public class RoundEventAggregator : IRoundEventAggregator
{
	public RoundEventAggregator()
	{
		LevelOpend = new UnityEvent<int>();
		PositionChipsCanged = new UnityEvent<int[]>();
	}

	public UnityEvent<int> LevelOpend { get; private set; }

	public UnityEvent<int[]> PositionChipsCanged { get; private set; }
}