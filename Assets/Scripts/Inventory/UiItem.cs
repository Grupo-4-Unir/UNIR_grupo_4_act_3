using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    public item _item;

    [SerializeField]
    Image image;

    [SerializeField]
    TMPro.TextMeshProUGUI itemName;

    public static event Action OnItemClicked;

    [SerializeField]
    Color[] colors;   

    private void OnEnable()
    {
        OnItemClicked.Invoke();
        print("ui item enabled");

        itemName.text = _item.itemName;
        image.sprite = _item.itemImage;
      
    }

    public void SetColor()
    {
        print("Start set color");

        var inventoryManager = FindAnyObjectByType<InventoryManager>();

        if (!inventoryManager.inventoryScriptable.itemActive)
        {
            print("no active item");

            GetComponent<Image>().color = colors[0];
            return;
        }
        else
        {
            print("active item is " + inventoryManager.inventoryScriptable.itemActive.itemName);

            if (inventoryManager.inventoryScriptable.itemActive.itemName == _item.itemName)
            {
                print("this is the active item");
                GetComponent<Image>().color = colors[1];
            }

            else
            {
                print("not the  active item");
                GetComponent<Image>().color = colors[0];
            }

        }
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

        OnItemClicked.Invoke();

    }

    void ResetItemsColors()
    {
        print("Colors reset");

        var items = transform.parent.GetComponentsInChildren<UiItem>();

        foreach (var item1 in items)
        {
            item1.GetComponent<Image>().color = colors[0];
        }
    }



}
