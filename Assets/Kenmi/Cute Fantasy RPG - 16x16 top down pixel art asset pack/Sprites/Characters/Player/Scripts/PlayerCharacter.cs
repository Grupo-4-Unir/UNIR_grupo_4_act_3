using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerCharacter : BaseCharacter
{
    [SerializeField] InputActionReference move;
    Animator animator;

    [SerializeField]
    private bool canMove = true;
    public bool CanMove { get => canMove; set => canMove = value; }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move.action.Enable();
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

    }

    protected override void Update()
    {
        if (!CanMove) return;

        base.Update();
        rawMove = move.action.ReadValue<Vector2>();
        Move(rawMove);
        MoveAnimations();
    }

    private void OnDisable()
    {
        move.action.Disable();
        move.action.started -= OnMove;
        move.action.performed -= OnMove;
        move.action.canceled -= OnMove;
    }

    Vector2 rawMove;

    

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.action.ReadValue<Vector2>();
    }
    private void MoveAnimations()
    {
        if (rawMove != Vector2.zero)
        {
            animator.SetBool("walking", true);

            animator.SetFloat("inputH", rawMove.x);
            animator.SetFloat("inputV", rawMove.y);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
}
