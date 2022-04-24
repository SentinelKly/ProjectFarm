using UnityEngine;

public class TomatoTurret : MonoBehaviour
{
	public float targetRange = 15f;
	public float lockOnSpeed = 8f;
	private GameObject _currentTarget;
	private Vector3 _defaultPos;

	private void Start()
	{
		_defaultPos = transform.position;
		InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
	}

	private void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closestEnemy = null;
		float closestDistance = Mathf.Infinity;

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
		{
			_currentTarget = closestEnemy;
		}

		else
			_currentTarget = null;
	}

	private void Update()
	{
		Vector3 turretDir;
		
		if (!_currentTarget)
		{
			turretDir = _defaultPos;
		}
		
		else
		{
			turretDir = _currentTarget.transform.position - transform.position;
		}
		
		Quaternion lookRotation = Quaternion.LookRotation(turretDir);
		Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lockOnSpeed).eulerAngles;
		
		transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, targetRange);
	}
}
