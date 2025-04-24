using UnityEngine;

public class Target : MonoBehaviour
{
    public float currentHealth = 400f;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}