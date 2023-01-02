using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;

#region Send Messages
    // Fonctions pour les Send Messages
    public void OnMove(InputValue value)
    {
        _movement.Move(value.Get<Vector2>());
    }

    public void OnJump(InputValue value)
    {
        _movement.Jump();
    }
#endregion

#region Unity Events
    // Fonctions pour les Unity Events
    public void MoveCharacter(InputAction.CallbackContext ctx)
    {
        _movement.Move(ctx.ReadValue<Vector2>());
    }

    public void JumpCharacter(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _movement.Jump();
        }
        else if (ctx.canceled)
        {
            _movement.CancelJump();
        }
    }
#endregion

}
