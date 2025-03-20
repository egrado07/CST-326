using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	private GameObject turret;
	public Vector3 positionOffset;
	private Renderer rend;
	private Color startColor;
	//public Vector3 positionOffset;
void Start()
{
	rend = GetComponent<Renderer>();
	startColor = rend.material.color;


	
}
void OnMouseEnter()
{
	
	rend.material.color = hoverColor;
	}

void OnMouseDown()
{	
	
	rend.material.color = hoverColor;
GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
if (turretToBuild != null)
{
    turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
}

	}



	void OnMouseExit(){
		rend.material.color = startColor;

	}
}