using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    public float damage = 10f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
