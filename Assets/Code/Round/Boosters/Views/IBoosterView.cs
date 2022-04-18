using UnityEngine;
using UnityEditor;

public interface IBoosterView
{
	bool IsActive { get; set; }

	void Show();
	void Hide();
}