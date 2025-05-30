using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleSelectUI : MonoBehaviour, IPointerDownHandler
{

    public SafeKeys SelectionKey;
    private bool IsSelected;
    public void OnPointerDown(PointerEventData eventData)
    {
        IsSelected = !IsSelected;

        if(IsSelected)
        {
            PlayerPrefs.SetInt(SelectionKey.ToString(), 1);
        }
        else
        {
            PlayerPrefs.SetInt(SelectionKey.ToString(), 0);
        }
    }

    public string GetSelection()
    {
        if(IsSelected)
        {
            return SelectionKey.ToString();
        }
        else
        {
            return "";
        }
    }
}