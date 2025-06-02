using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
	public static bool HitLevelSelect;
	public GameObject MainMenuCanvas;
	public GameObject PuzzleSelectCanvas;

	public void HitLevelSelectButton()
	{
		HitLevelSelect = true;
	}

    private void Start()
    {
		if (!HitLevelSelect)
		{
			MainMenuCanvas.SetActive(true);
			PuzzleSelectCanvas.SetActive(false);
		}
		else
		{
			MainMenuCanvas.SetActive(false);
			PuzzleSelectCanvas.SetActive(true);
		}
    }
}
