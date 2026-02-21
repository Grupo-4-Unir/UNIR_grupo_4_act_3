using UnityEngine;

public class itemInteractuable : MonoBehaviour
{
    public item _item;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    InventoryScriptable inventoryScriptable;    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _item.itemImage;

        if(CheckItem(_item.itemName))
            gameObject.SetActive(false);
    }

    public void TakeItem()
    {
        inventoryScriptable.items.Add(_item);
        gameObject.SetActive(false);
    }


    bool CheckItem(string itemName)
    { 
        var finded = false;

        foreach (var item in inventoryScriptable.items)
        {
            if(item.itemName == itemName)
                finded = true;
        }

        return finded;
    }
}
