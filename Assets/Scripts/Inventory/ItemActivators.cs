using UnityEngine;
using UnityEngine.Events;

public class ItemActivators : MonoBehaviour
{

    public string itemName;

    [SerializeField]
    InventoryScriptable inventoryScriptable;

    public UnityEvent onItemActivated;

    public void CheckItem()
    {
        var containsItem = false;

        foreach (var item in inventoryScriptable.items)
        {
            if (itemName == item.itemName)
                containsItem = true;
        }

        if (containsItem)
            onItemActivated.Invoke();
    }


    
}
