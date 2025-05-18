using System.Collections.Generic;
using UnityEngine;

public class InverseSwitch : Switch
{
    public override void FlipConnectedSwitches()
    {
        foreach(Switch sw in connectedSwitches)
        {
            sw.OnlyFlipSelf();
        }

        OnActivatedSwitch();
    }

    public override void AssignSwitches(List<Switch> availableSwitches)
    {
        connectedSwitches = availableSwitches;
    }
}
