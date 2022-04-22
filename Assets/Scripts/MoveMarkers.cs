using System;
using UnityEngine;

public class MoveMarkers : MonoBehaviour
{
	private Transform[] _markerList;

	public Transform[] GetMarkerList()
	{
		return _markerList;
	}

	private void Awake()
	{
		_markerList = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			_markerList[i] = transform.GetChild(i);
		}
	}
}