using System.Collections.Generic;
using UnityEngine;

public class OnlyOnSwitch : Switch
{
    public override void FlipConnectedSwitches()
    {
        OnlyFlipSelf();



        OnActivatedSwitch?.Invoke();
    }
}
