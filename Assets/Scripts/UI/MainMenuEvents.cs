using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
	private UIDocument document;
	private Button button;
    private List<Button> menuButtons = new();

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        button = document.rootVisualElement.Q("StartGameButton") as Button;

        menuButtons = document.rootVisualElement.Query<Button>().ToList();
    }
    private void OnEnable()
    {
        button.RegisterCallback<ClickEvent>(OnPlayGameClick);
        foreach (Button btn in menuButtons)
        {
            btn.RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        foreach (Button btn in menuButtons)
        {
            btn.UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("start button");
    }

    private void OnAllButtonsClick(ClickEvent evt)
    {
        Debug.Log("Sound");
    }
}
