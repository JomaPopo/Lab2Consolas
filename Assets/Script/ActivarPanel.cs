using UnityEngine;

public class ActivarPanel : MonoBehaviour
{
    // Arrastra aquí el panel desde el inspector
    public GameObject panelMeta;

    private void Start()
    {
        // Asegurarse de que el panel esté desactivado al inicio
        if (panelMeta != null)
            panelMeta.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona tiene el tag "Meta"
        if (other.CompareTag("Meta"))
        {
            if (panelMeta != null)
            {
                panelMeta.SetActive(true); // Activa el panel
            }
        }
    }
}
