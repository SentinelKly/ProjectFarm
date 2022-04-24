using System;
using UnityEditorInternal;
using UnityEngine;

public class PlacementUnit : MonoBehaviour
{
	private void OnMouseOver()
	{
		gameObject.GetComponent<Renderer> ().material.color = Color.green;
	}

	private void OnMouseExit()
	{
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}
}
