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

      
        Vector3 myPos = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 targetPos = new Vector3(currentTarget.transform.position.x, 0f, currentTarget.transform.position.z);
        float distance = Vector3.Distance(myPos, targetPos);

  
        Vector3 lookDirection = currentTarget.transform.position - transform.position;
        lookDirection.y = 0f;
        if (lookDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        if (distance <= range)
        {
         
            GetComponent<MovementController>().Stop();

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