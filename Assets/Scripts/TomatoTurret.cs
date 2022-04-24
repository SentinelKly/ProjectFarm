using UnityEngine;

public class TomatoTurret : MonoBehaviour
{
	public float targetRange = 15f;
	private Transform _currentTarget;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, targetRange);
	}
}
