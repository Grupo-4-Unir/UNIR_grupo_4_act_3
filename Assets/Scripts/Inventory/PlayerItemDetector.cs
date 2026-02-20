using UnityEngine;

public class PlayerItemDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item"))
        {
            collision.GetComponent<itemInteractuable>().TakeItem();
        }
    }
}
