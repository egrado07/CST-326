using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject buildEffect;
	public GameObject sellEffect;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void BuildTurretOn(Node node)
{
    // Check if player has enough money
    if (PlayerStats.Money < turretToBuild.cost)
    {
        Debug.Log("Not enough $!");
        return;
    }

    // Deduct money from player
    PlayerStats.Money -= turretToBuild.cost;

    // Instantiate the turret at the node position
    GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
    node.turret = turret;

    // Create build effect
    if (buildEffect != null)
    {
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f); // Destroy the effect after 5 seconds
    }

    Debug.Log("Turret built! Money left: " + PlayerStats.Money);
}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretToBuild ()
	{
		return turretToBuild;
	}

}