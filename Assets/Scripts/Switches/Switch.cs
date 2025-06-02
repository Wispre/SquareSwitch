using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Switch : MonoBehaviour
{
	public static Action OnActivatedSwitch;

	public bool isOn { get; private set; } = false;
	public ColorOptions colorOptions;

	private Image img;
	protected List<Switch> connectedSwitches = new();

	private void Awake()
	{
		img = gameObject.GetComponent<Image>();
		img.color = colorOptions.Color2;
	}

	public void OnlyFlipSelf()
	{
		isOn = !isOn;

		if (isOn)
		{
			img.color = colorOptions.Color1;
		}
		else
		{
			img.color = colorOptions.Color2;
		}
	}

	public virtual void FlipConnectedSwitches()
	{
		OnlyFlipSelf();

		foreach (Switch sw in connectedSwitches)
		{
			sw.OnlyFlipSelf();
		}

		OnActivatedSwitch?.Invoke();
	}

	public virtual void AssignSwitches(List<Switch> availableSwitches)
	{
		SimpleAssign(availableSwitches, connectedSwitches);
	}

	protected void SimpleAssign(List<Switch> availableSwitches, List<Switch> addTo)
	{
        List<Switch> available = new(availableSwitches);
        available.Remove(this);

        List<Switch> usedSwitches = new();
        int canAffectAmount = Random.Range(2, available.Count - 1);

        for (int i = 0; i < canAffectAmount; i++)
        {
            var index = Random.Range(0, available.Count);
            addTo.Add(available[index]);
            usedSwitches.Add(available[index]);
            available.RemoveAt(index);
        }
    }
}
