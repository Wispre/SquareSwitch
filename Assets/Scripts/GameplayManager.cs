using UnityEngine;

public class GameplayManager : MonoBehaviour
{
	public GameObject gameOverCanvas;
	public SwitchManager switchManager;

    private void OnEnable()
    {
        SwitchManager.OnGameFinished += ShowGameOver;
    }

    private void OnDisable()
    {
        SwitchManager.OnGameFinished -= ShowGameOver;
    }

    private void ShowGameOver()
	{
		gameOverCanvas.SetActive(true);
	}
}
