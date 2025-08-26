using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    private Vector2 moveInput;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        if (move.sqrMagnitude > 0.01f)
        {
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);

            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
