using UnityEngine;
using UnityEngine.UI;

public class ToggleSelectUI : MonoBehaviour
{
    public Sprite SelectedSprite;
    public Sprite UnselectedSprite;
    public SafeKeys SelectionKey;

    public Image ToggleImage;

    public void ToggleSprite(bool state)
    {
        if(state == true)
        {
            ToggleImage.sprite = SelectedSprite;
        }
        else
        {
            ToggleImage.sprite = UnselectedSprite;
        }
    }
}