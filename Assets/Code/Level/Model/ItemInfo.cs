[System.Serializable]
public class ItemInfo
{
	public float PositionX;
	public float PositionY;
	public float PositionZ;

	public float RotateX;
	public float RotateY;
	public float RotateZ;
	public float RotateW;

	public float ScaleX;
	public float ScaleY;
	public float ScaleZ;

	public string Tag;

	public string Name;

	public int NUMBER;
	public int PreviousNumber;
	public int NextNumber;

	public bool IsTriger;
	public string TargetNames;

	public int DifferentlyNextNumber;
	public int DifferentlyPreviousNumber;

	public ItemInfo() { }

	public ItemInfo(
		float px,float py, float pz,
		float rx, float ry, float rz, float rw,
		float sx, float sy, float sz,
		string tag)
	{
		PositionX = px;
		PositionY = py;
		PositionZ = pz;

		RotateX = rx;
		RotateY = ry;
		RotateZ = rz;
		RotateW = rw;

		ScaleX = sx;
		ScaleY = sy;
		ScaleZ = sz;

		Tag = tag;
	}
}
