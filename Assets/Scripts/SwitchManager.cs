using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SwitchManager : MonoBehaviour
{
    public static event Action OnGameFinished;

	public List<Switch> Switches = new();
    private bool allSwitchesOff;
    private List<Switch> usedSwitches = new();
    private List<Switch> unusedSwitches = new();
    private bool setupComplete = false;

    private void OnEnable()
    {
        Switch.OnActivatedSwitch += CheckIfAllSwitchesOff;
    }

    private void OnDisable()
    {
        Switch.OnActivatedSwitch -= CheckIfAllSwitchesOff;
    }

    private void Start()
    {
        unusedSwitches = new List<Switch>(Switches);
        SetupSwitches();
        FlipThreeSwitches();
    }

    private void FlipThreeSwitches()
    {
        for(int i = 0; i < 3; i++)
        {
            var index = Random.Range(0, unusedSwitches.Count);
            unusedSwitches[index].FlipConnectedSwitches();
            usedSwitches.Add(unusedSwitches[index]);
            Debug.Log(unusedSwitches[index].gameObject.name);
            unusedSwitches.RemoveAt(index);
        }

        if (allSwitchesOff)
        {
            foreach(Switch sw in usedSwitches)
            {
                sw.FlipConnectedSwitches();
            }

            AddSwitchesBack();
            FlipThreeSwitches();
        }

        setupComplete = true;
    }

    private void SetupSwitches()
    {
        for(int i = 0; i < Switches.Count; i++)
        {
            Switches[i].AssignSwitches(Switches);
        }
    }

    private void CheckIfAllSwitchesOff()
	{
        for(int i = 0; i < Switches.Count; i++)
        {
            if (Switches[i].isOn)
            {
                allSwitchesOff = false;
                return;
            }
        }

        allSwitchesOff = true;
        if (setupComplete)
        {
            OnGameFinished?.Invoke();
            Debug.Log("Win");
        }
	}

    private void AddSwitchesBack()
    {
        unusedSwitches.AddRange(usedSwitches);
        unusedSwitches.Clear();
    }
}
