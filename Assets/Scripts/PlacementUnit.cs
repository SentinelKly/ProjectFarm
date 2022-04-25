using UnityEngine;

public class PlacementUnit : MonoBehaviour
{
	private void OnMouseOver()
	{
		//gameObject.GetComponent<Renderer> ().material.color = Color.green;
		gameObject.GetComponent<Renderer> ().material.SetColor("_Color", Color.green);
	}

	private void OnMouseExit()
	{
		//gameObject.GetComponent<Renderer> ().material.color = Color.white;
		gameObject.GetComponent<Renderer> ().material.SetColor("_Color", Color.white);
	}
}
