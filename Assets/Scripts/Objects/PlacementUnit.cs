using UnityEngine;

namespace Objects
{
	public class PlacementUnit : MonoBehaviour
	{
		public GameObject turret;
		
		private GameObject _currentCrop;
		private bool _planted;
		private float _randomRot;

		private void Start()
		{
			_randomRot = Random.Range(1.0f, 360.0f);
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
	}
}