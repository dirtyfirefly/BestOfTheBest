using UnityEngine;

public static class VectorExtensions
{
	public static bool EquilsVectors(this Vector3 vector1, Vector3 vector2)
	{
		return vector1.x == vector2.x && vector1.y == vector2.y && vector1.z == vector2.z;
	}
}
