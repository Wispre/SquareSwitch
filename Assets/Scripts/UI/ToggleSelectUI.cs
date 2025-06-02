using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleSelectUI : MonoBehaviour
{
    [Header("Visuals")]
    public Sprite SelectedSprite;
    public Sprite UnselectedSprite;
    public Image ToggleImage;
    [Space]
    public SafeKeys SelectionKey;
    public UnityEvent<SafeKeys, bool> OnToggled;
    public PuzzleSettings settings;
    private Toggle toggle;

    public void ToggleSprite(bool state)
    {
        if (state == true)
        {
            ToggleImage.sprite = SelectedSprite;
        }
        else
        {
            ToggleImage.sprite = UnselectedSprite;
        }

        OnToggled?.Invoke(SelectionKey, state);
    }

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Start()
    {
        toggle.isOn = settings.SettingsToUse.Contains(SelectionKey);
    }
}