using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    public item _item;

    [SerializeField]
    Image image;

    [SerializeField]
    TMPro.TextMeshProUGUI itemName;

    [SerializeField]
    Color[] colors;

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

    public void SetActiveItem()
    {
        ResetItemsColors();

        if (FindAnyObjectByType<InventoryManager>().SetItemActive(_item))
                        GetComponent<Image>().color = colors[1];
        else
            GetComponent<Image>().color = colors[0];

    }

    void ResetItemsColors()
    {      
        var items = transform.parent.GetComponentsInChildren<UiItem>();

        foreach (var item1 in items)
        {
            item1.GetComponent<Image>().color = colors[0];
        }
    }

}
