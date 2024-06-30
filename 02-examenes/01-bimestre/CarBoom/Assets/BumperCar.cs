using UnityEngine;

public class BumperCar : MonoBehaviour
{
    public float health = 100f;
    public float collisionDamage = 10f;
    public float powerUpHealth = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        BumperCar otherCar = collision.gameObject.GetComponent<BumperCar>();
        if (otherCar != null)
        {
            // Only the car being hit loses health
            otherCar.TakeDamage(collisionDamage);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            // Handle car destruction, respawn or game over
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            GainHealth(powerUpHealth);
            Destroy(other.gameObject);
        }
    }

    public void GainHealth(float amount)
    {
        health += amount;
        if (health > 100f)
        {
            health = 100f; // Cap the health at 100
        }
    }
}