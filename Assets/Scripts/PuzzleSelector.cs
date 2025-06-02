using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PuzzleSelector")]
public class PuzzleSelector : ScriptableObject
{
	[Header("Default")]
	public Switch DefaultSwitch;

	private List<Switch> Switches = new();
	private bool UseTimer;


	public void AddSwitches(List<Switch> switches)
	{
		Switches = switches;
	}

	public void TimeThePlayer(bool useTimer)
	{
		UseTimer = useTimer;
	}

	public void ResetSelector()
	{
		Switches.Clear();
		UseTimer = false;
	}
}
