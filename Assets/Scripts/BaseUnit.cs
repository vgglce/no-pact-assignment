using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    protected AttackController attackController;
    protected MovementController movementController;

    protected virtual void Awake()
    {
        attackController = GetComponent<AttackController>();
        movementController = GetComponent<MovementController>();
    }

    public void Move(Vector3 position)
    {
        if (movementController != null)
        {
            movementController.MoveTo(position);
        }
    }

    public void Attack(Target target)
    {
        if (attackController != null)
        {
            attackController.AttackTarget(target);
        }
    }
}