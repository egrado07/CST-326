using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    public GameObject turretPrefab;
    public int turretCost = 50;

    void OnMouseDown()
    {
        if (PlayerStats.Money < turretCost)
        {
            Debug.Log(" Not enough money!");
            return;
        }

        PlayerStats.Money -= turretCost;
        Instantiate(turretPrefab, transform.position, Quaternion.identity);
        Debug.Log(" Placed turret! Remaining Money: " + PlayerStats.Money);
    }
}
