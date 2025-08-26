using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSetup : MonoBehaviour
{
    public Camera playerCamera;

    private void Start()
    {
        if (playerCamera != null)
        {
            playerCamera.enabled = true;

            var input = GetComponent<PlayerInput>();
            if (input.playerIndex == 0)
                playerCamera.rect = new Rect(0, 0, 0.5f, 1); // izquierda
            else if (input.playerIndex == 1)
                playerCamera.rect = new Rect(0.5f, 0, 0.5f, 1); // derecha
        }
    }
}
