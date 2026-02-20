using UnityEngine;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{

    [SerializeField]
    GameObject dialogIcon, dialogBox;

    [SerializeField]
    TMPro.TextMeshProUGUI dialogText, npcName;

    [SerializeField] InputActionReference talk;

    public bool canTalk = false;
    public bool onTalk = false;

    public static DialogManager Instance { get; private set; }

    PlayerCharacter player;


    Dialoger currentDialoger;

    private void OnEnable()
    {
        talk.action.Enable();       
        talk.action.performed += OnTalk;
        player = FindAnyObjectByType<PlayerCharacter>();

    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HideIconDialog();
    }

    public void ShowIconDialog(Transform dialogerTransform, Dialoger dialoger)
    {
        dialogIcon.SetActive(true);
        dialogIcon.transform.position = dialogerTransform.position;
        dialogBox.transform.position = dialogerTransform.position;
        canTalk = true;
        currentDialoger = dialoger;
        npcName.text = dialoger.npcName;
    }

    public void HideIconDialog()
    {
        if(dialogIcon.activeInHierarchy)
            dialogIcon.SetActive(false);

        canTalk = false;
    }

    public void OnTalk(InputAction.CallbackContext context)
    { 
        if (!canTalk || !currentDialoger) return;        

        //print("Talk action performed");

        if (!onTalk)
        {
            player.CanMove = false;
            onTalk = true;
            dialogIcon.SetActive(false);
            StartDialogText();
        }
        else 
        {
            NextDialog();
        }
        
    }

    public void StartDialogText()
    {
        dialogBox.SetActive(true);       
        NextDialog();
    }


    public void NextDialog()
    {
        if (EvaluateIfEndDialog())
        return;

        dialogText.text = currentDialoger.dialogs[currentDialoger.ActiveNode];
        currentDialoger.ActiveNode++;
        
    }

    public bool EvaluateIfEndDialog()
    {
        if (currentDialoger.ActiveNode >= currentDialoger.dialogs.Length)
        {
            EndDialog();
            //print("End of dialog");
            return true;
        }
        else
        {
            return false;
        }

    }

    public void EndDialog()
    {
        HideIconDialog();       
        dialogBox.SetActive(false);        
        onTalk = false;
        currentDialoger.ActiveNode = 0;
        player.CanMove = true;
        currentDialoger.OnDialogEnd.Invoke();
    }

    public void OutOfDialogBox()
    {
        HideIconDialog();
        dialogBox.SetActive(false);
        onTalk = false;
        currentDialoger.ActiveNode = 0;
        player.CanMove = true;        
    }



}
