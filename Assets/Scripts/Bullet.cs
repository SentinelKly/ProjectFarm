using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform _target;
	private float _speed = 20f;
	private bool _active;

	public void SetParams(Transform target, float speed)
	{
		_target = target;
		_speed = speed;
		_active = true;
	}
	
	private void Update()
	{
		if (_active)
		{
			if (_target == null)
			{
				Destroy(gameObject);
				return;
			}

			Vector3 direction = _target.position - transform.position;
			float movement = Time.deltaTime * _speed;

			if (direction.magnitude <= 1f)
			{
				Destroy(_target.gameObject);
			}
			
			transform.Translate(direction * movement, Space.World);
		}
	}
}
