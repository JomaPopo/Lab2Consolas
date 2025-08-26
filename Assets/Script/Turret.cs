using UnityEngine;
using UnityEngine.InputSystem;

public class Turret : MonoBehaviour
{
    public Transform turretTransform;
    public float rotationSpeed = 360f;

    private Vector2 aimInput;

    public void OnAim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (aimInput.sqrMagnitude > 0.1f)
        {
            float angle = Mathf.Atan2(aimInput.x, aimInput.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
            turretTransform.rotation = Quaternion.RotateTowards(
                turretTransform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
