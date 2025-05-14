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
        GiveSwitchesRandomControl();
        FlipThreeSwitches();
    }

    private void FlipThreeSwitches()
    {
        for(int i = 0; i < 3; i++)
        {
            var index = Random.Range(0, unusedSwitches.Count);
            unusedSwitches[i].FlipConnectedSwitches();
            usedSwitches.Add(unusedSwitches[i]); //!remove this
            Debug.Log(unusedSwitches[i].gameObject.name);
            unusedSwitches.RemoveAt(i);
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

    private void GiveSwitchesRandomControl()
    {
        for (int i = 0; i < Switches.Count; i++)
        {
            var amount = Random.Range(2, Switches.Count - 2);
            AssignSwitchesToSwitch(Switches[i], amount);
        }
    }

    private void AssignSwitchesToSwitch(Switch sw, int amount)
    {
        unusedSwitches.Remove(sw);

        if(amount > unusedSwitches.Count)
        {
            amount = unusedSwitches.Count;
        }

        for(int i = 0; i < amount; i++)
        {
            var index = Random.Range(0, unusedSwitches.Count);
            usedSwitches.Add(unusedSwitches[index]);
            sw.AddSwitch(unusedSwitches[index]);
            unusedSwitches.RemoveAt(index);
        }
        AddSwitchesBack();
        unusedSwitches.Add(sw);
    }

    private void AddSwitchesBack()
    {
        foreach(Switch sw in usedSwitches)
        {
            unusedSwitches.Add(sw);
        }

        usedSwitches.Clear();
    }
}
