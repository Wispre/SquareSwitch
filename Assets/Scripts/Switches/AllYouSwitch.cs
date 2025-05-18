using UnityEngine;

public class AllYouSwitch : Switch
{
    public override void FlipConnectedSwitches()
    {
        foreach (Switch sw in connectedSwitches)
        {
            sw.OnlyFlipSelf();
        }

        OnActivatedSwitch?.Invoke();
    }
}
