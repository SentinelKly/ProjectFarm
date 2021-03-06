using UnityEngine;

namespace Objects
{
	public class CropWeapon : MonoBehaviour
	{
		[Header("Reference Objects")]
		public GameObject bulletPrefab;
		public Transform bulletSpawner;
		
		[Header("Speed Modifiers")]
		public float rateOfFire = 1f;
		public float projectileSpeed = 30f;
		
		private float _fireDelay;
		private EnemySeeker _seeker;
		private GameObject _target;

		private void Start()
		{
			_seeker = GetComponent<EnemySeeker>();
		}

		private void Update()
		{
			_target = _seeker.GetTarget();
			
			if (!_target) return;

			if (_fireDelay <= 0f)
			{
				FireAtEnemy();
				_fireDelay = 1f / rateOfFire;
			}

			_fireDelay -= Time.deltaTime;
		}

		private void FireAtEnemy()
		{
			var bulletObj = Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);
			var bullet = bulletObj.GetComponent<IProjectile>();
			bullet.LaunchProjectile(_target.transform, projectileSpeed);
		}
	}
}