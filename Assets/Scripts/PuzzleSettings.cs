using System.Collections.Generic;
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
