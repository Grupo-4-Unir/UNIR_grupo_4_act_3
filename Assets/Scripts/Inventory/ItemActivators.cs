using UnityEngine;
using UnityEngine.Events;

public class ItemActivators : MonoBehaviour
{

    public string itemName, goodMessage, badmMssage;

    public bool requireItem;

    [SerializeField]
    TMPro.TextMeshProUGUI messageText;

    [SerializeField]
    InventoryScriptable inventoryScriptable;

    [SerializeField]
    CanvasGroup canvasGroup;

    [SerializeField]
    float fadeTime;

    public UnityEvent onItemActivated;

    public void CheckItem()
    {
        if (!requireItem)
        {
            onItemActivated.Invoke();
            return;
        }

        if (!inventoryScriptable.itemActive)
        {
            SetMessage(badmMssage);
            return;
        }

        if (inventoryScriptable.itemActive.itemName != itemName)
        {
            SetMessage(badmMssage);
            return;
        }


        SetMessage(goodMessage);
        onItemActivated.Invoke();
    }

    private void Update()
    {
        if (!canvasGroup)
            return;

        if(canvasGroup.alpha>0)
        canvasGroup.alpha -= fadeTime * Time.deltaTime;
    }

    public void SetMessage(string message)
    {
        if (message.Length == 0 || !canvasGroup)
            return;
        
        messageText.text = message;
        canvasGroup.alpha = 1;
    }



}
