using UnityEngine;
using UnityEngine.UI;
using TMPro; // Necesario para TextMeshPro

public class PlayerVidaTMP : MonoBehaviour
{
    public int vidaMax = 100;      // Vida máxima
    public int vida;               // Vida actual
    public Image barraVida;        // Imagen tipo Filled Horizontal
    public TMP_Text textoVida;     // Texto TMP que muestra la vida

    void Start()
    {
        vida = vidaMax;
        ActualizarUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            RecibirDanio(10);   // Cada bala enemiga quita 10 de vida
            Destroy(other.gameObject); // Opcional: destruye la bala
        }
    }

    void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0)
            vida = 0;

        ActualizarUI();
        Debug.Log("Vida actual: " + vida);
    }

    void ActualizarUI()
    {
        if (barraVida != null)
        {
            barraVida.fillAmount = (float)vida / vidaMax; // Ajusta la barra
        }

        if (textoVida != null)
        {
            textoVida.text = vida.ToString(); // Actualiza el texto TMP
        }
    }
}
