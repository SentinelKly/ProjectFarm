using UnityEngine;

namespace Objects
{
	public class Bullet : MonoBehaviour, IProjectile
	{
		private Transform _target;
		private float _speed;
		private bool _active;

		public void LaunchProjectile(Transform target, float speed)
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
					var enemy = _target.GetComponent<Enemy>();
					enemy.TakeDamage();
				}
			
				transform.Translate(direction * movement, Space.World);
			}
		}
	}
}