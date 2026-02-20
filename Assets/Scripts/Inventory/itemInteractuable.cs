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
    }

    public void TakeItem()
    {
        inventoryScriptable.items.Add(_item);
        Destroy(gameObject);
    }
}
