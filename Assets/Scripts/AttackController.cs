using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 5f;
    public float fireRate = 1f;

    private float lastShotTime = 0f;
    private Target currentTarget;

    public void AttackTarget(Target target)
    {
        currentTarget = target;
    }

    private void Update()
    {
        if (currentTarget == null || currentTarget.IsDead()) return;

        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);

        if (distance <= range)
        {
            if (Time.time - lastShotTime >= fireRate)
            {
                currentTarget.TakeDamage(damage);
                lastShotTime = Time.time;
            }
        }
        else
        {
            GetComponent<MovementController>().MoveTo(currentTarget.transform.position);
        }
    }
}