using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaker : MonoBehaviour
{
	public PuzzleSettings settings;
	[Space]
	public Switch DefaultSwitchPrefab;
	public Switch DoubleSwitchPrefab;
	public Switch InverseSwitchPrefab;
	public Switch AllYouSwitch;

	private List<Switch> availableSwitches = new();
	private List<Switch> createdSwitches = new();

	public List<Switch> CreateSwitches(int amount, Transform parent)
	{
		GetAvailableSwitches();

        for (int i = 0; i < amount; i++)
		{
			int index = Random.Range(0, availableSwitches.Count);
			Switch sw = Instantiate(availableSwitches[index], parent);
			sw.name = $"Switch {i + 1} {sw.GetType().ToString()}";

			if(sw is InverseSwitch)
			{
				availableSwitches.Remove(InverseSwitchPrefab);

				if(availableSwitches.Count == 0)
				{
					availableSwitches.Add(DefaultSwitchPrefab);
				}
			}

			createdSwitches.Add(sw);
		}

		return createdSwitches;
	}

	private void GetAvailableSwitches()
	{
        CheckAndAdd(SafeKeys.DEFAULT_SWITCHES, DefaultSwitchPrefab);
		CheckAndAdd(SafeKeys.DOUBLE_SWITCHES, DoubleSwitchPrefab);
		CheckAndAdd(SafeKeys.INVERSE_SWITCHES, InverseSwitchPrefab);
		CheckAndAdd(SafeKeys.YOU_NOT_ME_SWITCHES, AllYouSwitch);

		if(availableSwitches.Count == 0)
		{
			availableSwitches.Add(DefaultSwitchPrefab);
		}
	}

	private void CheckAndAdd(SafeKeys key, Switch prefab)
	{
        if (settings.SettingsToUse.Contains(key)) availableSwitches.Add(prefab);
	}
}