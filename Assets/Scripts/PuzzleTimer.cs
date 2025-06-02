using UnityEngine;
using TMPro;
using System;

public class PuzzleTimer : MonoBehaviour
{
	public TMP_Text visual;
    public GameObject UI;
    public PuzzleSettings settings;
    private float elapsedtime;
    private bool useTimer;

    private void Start()
    {
        if (settings.SettingsToUse.Contains(SafeKeys.TIMER))
        {
            UI.SetActive(true);
            useTimer = true;
        }
        else
        {
            UI.SetActive(false);
            useTimer = false;
        }
    }

    private void Update()
    {
        if (useTimer)
        {
            elapsedtime += Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedtime);
            visual.text = string.Format("{0}h {1}m {2}s", (int)timeSpan.TotalHours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}
