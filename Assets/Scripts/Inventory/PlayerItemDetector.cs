using UnityEngine;

public class PlayerItemDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item"))
        {
            collision.GetComponent<itemInteractuable>().TakeItem();
        }

        if (collision.CompareTag("activator"))
        {
            collision.GetComponent<ItemActivators>().CheckItem();
        }
    }
}
