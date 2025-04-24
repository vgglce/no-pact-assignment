using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 targetPosition;
    private bool isMoving = false;

    public void MoveTo(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }
    public void Stop()
    {
        isMoving = false;
    }
    private void Update()
    {
        if (!isMoving) return;

        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}