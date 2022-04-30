using System;
using UI;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Objects
{
	public class PlacementUnit : MonoBehaviour
	{
		private GameObject _currentCrop;
		private bool _planted, _dragged;
		private float _randomRot;

		private void Start()
		{
			_randomRot = Random.Range(1.0f, 360.0f);
		}

		private void Update()
		{
			if (CropPurchase.DraggingCrop)
			{
				var highlight = GetComponent<Highlighter>();
				highlight.isEnabled = true;
			}

			else
			{
				var highlight = GetComponent<Highlighter>();
				highlight.isEnabled = false;
			}
		}

		private void OnMouseDown()
		{
			if (_planted)
			{
				Destroy(_currentCrop);
				_planted = false;
			}
		}

		private void OnMouseOver()
		{
			if (CropPurchase.DraggingCrop && !_planted && CropPurchase.GetCurrentCrop() != null)
				_dragged = true;

			if (_dragged && !Input.GetMouseButton(0))
			{
				_dragged = false;
				PlantCrop();
			}
		}

		private void OnMouseExit()
		{
			_dragged = false;
		}

		private void PlantCrop()
		{
			_currentCrop = Instantiate(CropPurchase.GetCurrentCrop(), transform.position, Quaternion.Euler(0f, _randomRot, 0f));
			_currentCrop.transform.Translate(0f, 1.85f, 0f, Space.Self);
			_planted = true;
		}
	}
}