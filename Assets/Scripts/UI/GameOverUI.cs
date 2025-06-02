using System;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
	public GameObject GameOverVisual;

    private void Start()
    {
        GameOverVisual.SetActive(false);
    }

    private void OnEnable()
    {
        SwitchManager.OnGameFinished += ShowVisual;
    }

    private void OnDisable()
    {
        SwitchManager.OnGameFinished -= ShowVisual;
    }

    private void ShowVisual()
    {
        GameOverVisual.SetActive(true);
    }
}
