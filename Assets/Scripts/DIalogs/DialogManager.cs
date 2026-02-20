using UnityEngine;

public class DialogManager : MonoBehaviour
{

    [SerializeField]
    GameObject dialogIcon;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HideIconDialog();
    }

    public void ShowIconDialog(Transform dialogerTransform)
    {
        dialogIcon.SetActive(true);
        dialogIcon.transform.position = dialogerTransform.position;
    }

    public void HideIconDialog()
    {
        dialogIcon.SetActive(false);
    }



}
