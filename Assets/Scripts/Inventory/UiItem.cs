using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    public item _item;

    [SerializeField]
    Image image;

    [SerializeField]
    TMPro.TextMeshProUGUI itemName;

    private void OnEnable()
    {
        itemName.text = _item.itemName;
        image.sprite = _item.itemImage;
    }

    public void SetData(item newitem)
    {
        _item = newitem;
        itemName.text = _item.itemName;
        image.sprite = _item.itemImage;
    }
    
}
