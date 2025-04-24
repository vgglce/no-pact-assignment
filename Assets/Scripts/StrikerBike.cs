using UnityEngine;

public class StrikerBike : BaseUnit
{
	public float hitpoints = 100f;

    private void Start()
    {
        attackController.damage = 5f;
        attackController.range = 10f;
        attackController.fireRate = 0.5f;
		
        movementController.speed = 8f;
    }
}