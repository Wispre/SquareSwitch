using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void FlipSwitch()
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

	public void FlipConnectedSwitches()
	{
		FlipSwitch();

		foreach (Switch sw in switches)
		{
			sw.FlipSwitch();
		}

		OnActivatedSwitch?.Invoke();
	}

	public void AddSwitch(Switch sw)
	{
		switches.Add(sw);
	}
}
