using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MoveMarkers markers;
    public float speed = 10.0f;

    private Transform _currentMarker;
    private Vector3 _direction;
    private int _mIndex;

    private void ChangeMarker()
    {
        _mIndex ++;

        _currentMarker = markers.GetMarkerList()[_mIndex];
        _direction = _currentMarker.position - transform.position;
        _direction.Normalize();
    }

    private void Update()
    {
        transform.Translate(_direction * (speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, markers.GetMarkerList()[_mIndex].position) < 0.3f)
        {
            if (_mIndex < markers.GetMarkerList().Length - 1)
                ChangeMarker();
            else
                Destroy(gameObject);
        }
    }
}
