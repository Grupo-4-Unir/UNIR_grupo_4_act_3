using System;
using UnityEngine;

public class PlayerDilalogDetection : MonoBehaviour
{     

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dialoger"))
        {
            print("Player entered dialog trigger " + collision.gameObject.name);
            DialogManager.Instance.ShowIconDialog(collision.gameObject.transform, collision.GetComponent<Dialoger>());
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("dialoger"))
        {
            print("Player entered dialog trigger " + collision.gameObject.name);
            DialogManager.Instance.EndDialog();
        }
    }
}
