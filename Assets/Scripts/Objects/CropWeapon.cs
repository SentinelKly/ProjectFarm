using UnityEngine;

namespace Objects
{
	public class CropWeapon : MonoBehaviour
	{
		public GameObject bulletPrefab;
		public Transform bulletSpawner;
		public float rateOfFire = 1f;
		
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
			var bullet = bulletObj.GetComponent<Bullet>();
			bullet.SetParams(_target.transform, 30f);
		}
	}
}