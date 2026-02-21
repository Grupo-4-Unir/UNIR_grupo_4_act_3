using UnityEngine;
using UnityEngine.UI;

public class PlayerActiveItemImage : MonoBehaviour
{
    Image image;
    public CanvasGroup canvasGroup;

    private void OnEnable()
    {
        UiItem.OnItemClicked += UpdateImage;
    }

    private void OnDisable()
    {
        UiItem.OnItemClicked -= UpdateImage;
    }
    private void Start()
    {
        image = GetComponent<Image>();
        UpdateImage();
    }

    public void UpdateImage()
    {
        var itemActive = FindAnyObjectByType<InventoryManager>().inventoryScriptable.itemActive;

        if (!itemActive)
        {
            canvasGroup.alpha = 0;
        }
        else 
        {
            image.sprite = itemActive.itemImage;
            canvasGroup.alpha = 1;
        }
        
    }

    
}
