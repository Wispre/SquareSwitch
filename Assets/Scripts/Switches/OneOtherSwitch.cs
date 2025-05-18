using System.Collections.Generic;
using UnityEngine;

public class OneOtherSwitch : Switch
{
    public override void FlipConnectedSwitches()
    {
        connectedSwitches[0].OnlyFlipSelf();
        OnActivatedSwitch?.Invoke();
    }

    public override void AssignSwitches(List<Switch> availableSwitches)
    {
        List<Switch> copy = new List<Switch>(availableSwitches);
        copy.Remove(this);
        var index = Random.Range(0, copy.Count);

        connectedSwitches.Add(copy[index]);
    }
}
