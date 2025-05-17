using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Switch : MonoBehaviour
{
	public static Action OnActivatedSwitch;

	public bool isOn { get; private set; } = false;
	private List<Switch> switches = new();
	public Image img;

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

		foreach (Switch sw in switches)
		{
			sw.OnlyFlipSelf();
		}

		OnActivatedSwitch?.Invoke();
	}

	public virtual void AssignSwitches(List<Switch> availableSwitches)
	{
		availableSwitches.Remove(this);

		List<Switch> usedSwitches = new();
		int amount = Random.Range(1, availableSwitches.Count - 1);

		for (int i = 0; i < amount; i++)
		{
			var index = Random.Range(0, availableSwitches.Count);
			switches.Add(availableSwitches[index]);
			usedSwitches.Add(availableSwitches[index]);
			availableSwitches.RemoveAt(index);
		}

		availableSwitches.AddRange(usedSwitches);
		availableSwitches.Add(this);
	}
}
