using System;
using UnityEngine;

public class PlacementUnit : MonoBehaviour
{
	private static readonly int Color1 = Shader.PropertyToID("_Color");

	private Material _plotMaterial;
	private Color _defaultColour;

	private void Start()
	{
		_plotMaterial = gameObject.GetComponent<Renderer>().material;
		_defaultColour = _plotMaterial.GetColor(Color1);
	}

	private void OnMouseOver()
	{
		_plotMaterial.color = Color.green;
	}

	private void OnMouseExit()
	{
		_plotMaterial.color = _defaultColour;
	}
}