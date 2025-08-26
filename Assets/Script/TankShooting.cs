using UnityEngine;
using UnityEngine.InputSystem;

public class TankShooting : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float fireRate = 0.5f;

    private float lastShotTime;

    public void OnFire(InputAction.CallbackContext context)
    {
        // Dispara solo si el bot�n fue presionado (no solo mantenido)
        if (context.started)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Time.time < lastShotTime + fireRate) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletForce;
        }

        lastShotTime = Time.time;
    }
}
