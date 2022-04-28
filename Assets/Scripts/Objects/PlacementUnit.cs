using UnityEngine;

namespace Objects
{
	public class PlacementUnit : MonoBehaviour
	{
		public GameObject turret;
		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private Material _plotMaterial;
		private Color _defaultColour;
		private GameObject _currentCrop;
		
		private bool _planted;
		private float _randomRot;

		private void Start()
		{
			_randomRot = Random.Range(1.0f, 360.0f);
			_plotMaterial = gameObject.GetComponent<Renderer>().material;
			_defaultColour = _plotMaterial.GetColor(Color1);
		}

		private void OnMouseDown()
		{
			if (!_planted)
			{
				_currentCrop = Instantiate(turret, transform.position, Quaternion.Euler(0f, _randomRot, 0f));
				_currentCrop.transform.Translate(0f, 1.85f, 0f, Space.Self);
				_planted = true;
			}

			else
			{
				Destroy(_currentCrop);
				_planted = false;
			}
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
}