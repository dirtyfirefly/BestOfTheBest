using UnityEngine;

public class BlockViewBase : MonoBehaviour
{
	public string Name;

	public int NUMBER;
	public int PreviousNumber;
	public int NextNumber;

	public bool IsTriger;
	public string TargetNames;

	public int DifferentlyNextNumber;
	public int DifferentlyPreviousNumber;

	private const int ChipPhCount = 5;

	private Transform[] _chipPhs;
	private Transform _boostPh;

	private void Start()
	{
		_chipPhs = new Transform[ChipPhCount];
		for (var i = 0; i < ChipPhCount; i++)
		{
			_chipPhs[i] = transform.Find($"ChipPh{i}");
		}

		_boostPh = transform.Find("BoostPh");
	}

	public Transform BoostPlaceholder => _boostPh;

	public Vector3 GetCentralPosition()
	{
		return _chipPhs[0].position;
	}

	public bool TryGetPostion(int positionNumber, out Vector3 position)
	{
		if (positionNumber < ChipPhCount && positionNumber > -1)
		{
			position = _chipPhs[positionNumber].position;
			return true;
		}

		position = Vector3.zero;
		return false;
	}
}
