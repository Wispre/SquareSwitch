using System.Collections.Generic;
using UnityEngine;

public class SingleSwitch : Switch
{
    public override void FlipConnectedSwitches()
    {
        OnlyFlipSelf();
        OnActivatedSwitch?.Invoke();
    }

    public override void AssignSwitches(List<Switch> availableSwitches) { }
}
