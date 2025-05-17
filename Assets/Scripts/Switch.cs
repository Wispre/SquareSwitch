using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Switch : MonoBehaviour
{
	public static Action OnActivatedSwitch;

	public bool isOn { get; private set; } = false;
	public Image img;

	protected List<Switch> connectedSwitches = new();

	private void Awake()
	{
		img = gameObject.GetComponent<Image>();
		img.color = Color.black;
	}

	public void OnlyFlipSelf()
	{
		isOn = !isOn;

		if (isOn)
		{
			img.color = Color.yellow;
		}
		else
		{
			img.color = Color.black;
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
		List<Switch> available = new(availableSwitches);
		available.Remove(this);

        List<Switch> usedSwitches = new();
		int canAffectAmount = Random.Range(2, available.Count - 1);

		for (int i = 0; i < canAffectAmount; i++)
		{
			var index = Random.Range(0, available.Count);
			connectedSwitches.Add(available[index]);
			usedSwitches.Add(available[index]);
            available.RemoveAt(index);
		}
	}
}
