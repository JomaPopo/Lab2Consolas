using UnityEngine;

public class TurretAI : MonoBehaviour
{
    [Header("Configuración")]
    public Transform turretHead;        // La parte que rota (la cabeza de la torreta)
    public Transform firePoint;         // Punto desde donde dispara
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 1f;
    public float rotationSpeed = 5f;
    public float shootingRange = 15f;  // Rango máximo para disparar

    private Transform target;
    private float lastShotTime;

    private void Update()
    {
        if (target == null) return;

        // Calculamos distancia al objetivo
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > shootingRange)
        {
            // Objetivo fuera de rango, dejar de seguir
            target = null;
            return;
        }

        // Rotar solo la cabeza hacia el objetivo (solo en eje Y)
        Vector3 direction = target.position - turretHead.position;
        direction.y = 0;  // para rotar solo horizontalmente
        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        turretHead.rotation = Quaternion.Slerp(turretHead.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Disparar si toca
        if (Time.time > lastShotTime + fireRate)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletForce;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.transform == target)
        {
            target = null;
        }
    }
}
