using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    public InventoryScriptable inventoryScriptable;

    private void Start()
    {
        //inventoryScriptable.items.Clear();
    }

    [SerializeField]
    private GameObject container;

    [SerializeField]
    GameObject uiItem;

    public void UpdateInventory()
    {
        var items = container.GetComponentsInChildren<UiItem>();

        foreach (var i in items)
        {
            Destroy(i.gameObject);
        }

        foreach (var item in inventoryScriptable.items)
        {
            var i = Instantiate(uiItem, container.transform);
            var _item = i.GetComponent<UiItem>();
            _item.SetData(item);
            _item.SetColor();
        }
    }

    public void AddItem(item newitem)
    {
        inventoryScriptable.items.Add(newitem);
        UpdateInventory();
    }

    public bool SetItemActive(item _item)
    {
        if (inventoryScriptable.itemActive != _item)
        {
            inventoryScriptable.itemActive = _item;
            return true;
        }        
        else
        {
            inventoryScriptable.itemActive = null;
            return false;
        }
            
    }

    
}
