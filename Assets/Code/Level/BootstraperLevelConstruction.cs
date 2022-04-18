using UnityEngine;

public class BootstraperLevelConstruction : MonoBehaviour
{
	void Start()
	{
		var saver = FindObjectOfType<LevelViewSaver>();
		saver?.SaveLevel();
	}
}
