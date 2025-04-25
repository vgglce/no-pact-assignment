using UnityEngine;

public class HeavyTank : BaseUnit
{
    public float hitpoints = 900f; 

    private void Start()
    {
        attackController.damage = 20f;
        attackController.range = 30f;
        attackController.fireRate = 1.5f;
        movementController.speed = 3f;
    }
}