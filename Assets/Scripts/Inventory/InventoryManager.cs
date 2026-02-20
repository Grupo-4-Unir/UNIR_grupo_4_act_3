using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    InventoryScriptable inventoryScriptable;

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
            i.GetComponent<UiItem>().SetData(item);
        }
    }

    public void AddItem(item newitem)
    {
        inventoryScriptable.items.Add(newitem);
        UpdateInventory();
    }
}
