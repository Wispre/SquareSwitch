using System.Collections.Generic;
using UnityEngine;

public class DoubleSwitch : Switch
{
	private List<Switch> connectedSwitchesTwo = new();
	private int index = 0;

	public override void FlipConnectedSwitches()
	{
		if(index == 0)
		{
			OnlyFlipSelf();
			foreach(Switch sw in connectedSwitches)
			{
				sw.OnlyFlipSelf();
			}
			index++;
		}
		else if (index == 1)
		{
			foreach(Switch sw in connectedSwitches)
			{
				sw.OnlyFlipSelf();
			}
			foreach(Switch sw in connectedSwitchesTwo)
			{
				sw.OnlyFlipSelf();
			}
			index++;
		}
		else
		{
			OnlyFlipSelf();
            foreach (Switch sw in connectedSwitchesTwo)
            {
                sw.OnlyFlipSelf();
            }
			index = 0;
        }
        OnActivatedSwitch?.Invoke();
    }

	public override void AssignSwitches(List<Switch> availableSwitches)
	{
		List<Switch> available = new(availableSwitches);
		available.Remove(this);
		List<Switch> usedSwitches = new();

		int canAffectAmount = Random.Range(2, available.Count - 1);

		for (int i = 0; i < canAffectAmount; i++)
		{
			var index = Random.Range(0, available.Count);
			connectedSwitches.Add(available[index]);
			usedSwitches.Add(available[index]);
			available.RemoveAt(index);
		}

        available.AddRange(usedSwitches);
		usedSwitches.Clear();

		canAffectAmount = Random.Range(2, available.Count - 1);
		for (int i = 0; i < canAffectAmount; i++)
		{
			var index = Random.Range(0, available.Count);
			connectedSwitchesTwo.Add(available[index]);
			usedSwitches.Add(available[index]);
			available.RemoveAt(index);
		}
	}

}
