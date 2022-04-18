using UnityEngine;
using UnityEditor;

public interface IBoosterFactory
{
	IBoosterView CreateBooster(string path, Transform parent);
}