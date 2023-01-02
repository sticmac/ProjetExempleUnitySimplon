using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _animator;
    [SerializeField] float _speed = 1;
    [SerializeField] float _jumpForce = 10;

    private Vector2 _movement = Vector2.zero;

    private void Reset() {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 movement)
    {
        _movement = movement;
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void CancelJump()
    {
        if (_rb.velocity.y > 0)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        }
    }

    private void FixedUpdate() {
        _rb.velocity = new Vector3(_movement.x * _speed, _rb.velocity.y, _movement.y * _speed);
        Vector3 velocityXZ = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);

        if (velocityXZ != Vector3.zero)
        {
            _rb.rotation = Quaternion.LookRotation(velocityXZ, Vector3.up);
        }

        _animator.SetFloat("Speed", velocityXZ.sqrMagnitude);
    }
}
