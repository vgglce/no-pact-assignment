using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    private BaseUnit selectedUnit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out BaseUnit unit))
                {
                    selectedUnit = unit;
                }
                else if (hit.collider.TryGetComponent(out Target target))
                {
                    selectedUnit?.Attack(target);
                }
                else
                {
                    selectedUnit?.Move(hit.point);
                }
            }
        }
    }
}