using System.Collections.Generic;
using UnityEngine;

public class PuzzleSelectFeeder : MonoBehaviour
{
	public PuzzleSettings Selector;
    
    private bool useDefaultPrefab;
    private bool useDoublePrefab;
    private bool useInversePrefab;
    private bool useYouNotMePrefab;
    private bool useTimer;

    public void SaveSelection(SafeKeys key, bool state)
    {
        switch (key)
        {
            case SafeKeys.DEFAULT_SWITCHES:
                useDefaultPrefab = state;
                break;

            case SafeKeys.DOUBLE_SWITCHES:
                useDoublePrefab = state;
                break;

            case SafeKeys.INVERSE_SWITCHES:
                useInversePrefab = state;
                break;

            case SafeKeys.YOU_NOT_ME_SWITCHES:
                useYouNotMePrefab = state;
                break;

            case SafeKeys.TIMER:
                useTimer = state;
                break;

            default:
                break;

        }
    }

    public void FeedSettings()
    {
        List<SafeKeys> keys = new();

        if (useDefaultPrefab) keys.Add(SafeKeys.DEFAULT_SWITCHES);
        if (useDoublePrefab) keys.Add(SafeKeys.DOUBLE_SWITCHES);
        if (useInversePrefab) keys.Add(SafeKeys.INVERSE_SWITCHES);
        if (useYouNotMePrefab) keys.Add(SafeKeys.YOU_NOT_ME_SWITCHES);
        if (useTimer) keys.Add(SafeKeys.TIMER);

        Selector.FeedSettings(keys);
    }

/*    private void Start()
    {
        useDefaultPrefab = Selector.SettingsToUse.Contains(SafeKeys.DEFAULT_SWITCHES);
        useDoublePrefab = Selector.SettingsToUse.Contains(SafeKeys.DOUBLE_SWITCHES);
        useInversePrefab = Selector.SettingsToUse.Contains(SafeKeys.INVERSE_SWITCHES);
        useYouNotMePrefab = Selector.SettingsToUse.Contains(SafeKeys.YOU_NOT_ME_SWITCHES);
        useTimer = Selector.SettingsToUse.Contains(SafeKeys.TIMER);
    }*/
}
