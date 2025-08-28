using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public float damage = 10f;

    [HideInInspector]
    public GameObject owner; // Referencia al tanque que disparó la bala

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destruye al enemigo
            Destroy(gameObject);       // Destruye la bala

            // Aumenta la kill del tanque que disparó
            if (owner != null)
            {
                ContadorKills contador = owner.GetComponent<ContadorKills>();
                if (contador != null)
                {
                    contador.AumentarKill();
                }
            }
        }

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
