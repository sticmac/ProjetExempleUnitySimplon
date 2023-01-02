using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        _movement.Move(new Vector2(inputX, inputY));
    }
}
