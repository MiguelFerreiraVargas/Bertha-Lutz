using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{

    public Image iconImage;

    public void SetItem(Sprite icon)
    {
        iconImage.sprite = icon;
        iconImage.enabled = true;
    }
}
