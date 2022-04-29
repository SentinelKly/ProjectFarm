using UnityEngine;

namespace Objects
{
    public class EnemySeeker : MonoBehaviour
    {
        public float targetRange = 15f;
        public float lockOnSpeed = 8f;
        
        private GameObject _currentTarget;

        public GameObject GetTarget()
        {
            return _currentTarget;
        }
        
        private void Start()
        {
            InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
        }

        private void Update()
        {
            if (!_currentTarget) return;
            
            var turretDir = _currentTarget.transform.position - transform.position;
            var lookRotation = Quaternion.LookRotation(turretDir);
            var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lockOnSpeed).eulerAngles;
		
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        private void UpdateTarget()
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject closestEnemy = null;
            var closestDistance = Mathf.Infinity;

            foreach (var enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }

            if (closestEnemy != null && closestDistance <= targetRange)
                _currentTarget = closestEnemy;

            else
                _currentTarget = null;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, targetRange);
        }
    }
}