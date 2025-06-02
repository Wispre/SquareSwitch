using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PuzzleSettings")]
public class PuzzleSettings : ScriptableObject
{
	public List<SafeKeys> SettingsToUse { get; private set; } = new();

	public void FeedSettings(List<SafeKeys> settingsKeys)
	{
		SettingsToUse.Clear();
		SettingsToUse = settingsKeys;
	}
}
