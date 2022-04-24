using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;

    private Transform _currentMarker;
    private Vector3 _direction;
    private int _mIndex;

    private void ChangeMarker()
    {
        _mIndex ++;

        _currentMarker = WaveSpawner.GetMarkerList()[_mIndex];
        _direction = _currentMarker.position - transform.position;
        _direction.Normalize();
    }

    private void Start()
    {
        ChangeMarker();
    }

    private void Update()
    {
        transform.Translate(_direction * (speed * Time.deltaTime), Space.World);

        if (Vector3.Distance(transform.position, _currentMarker.position) < 0.3f)
        {
            if (_mIndex < WaveSpawner.GetMarkerList().Length - 1)
                ChangeMarker();
            else
                Destroy(gameObject);
        }
    }
}
