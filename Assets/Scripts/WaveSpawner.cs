using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	[Header("Numeric Modifiers")]
	public int totalWaves;
	public float waveDelay = 5.0f;
	
	[Header("Object References")]
	public GameObject enemyPrefab;
	public Transform enemySpawn;

	private float _timeUntilWave = 5.0f;
	private int _waveCount;

	private static Transform[] _markerList;
	
	public static Transform[] GetMarkerList()
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

	private void Update()
	{
		if (_timeUntilWave <= 0)
		{
			if (_waveCount < totalWaves || totalWaves == 0)
			{
				_timeUntilWave = waveDelay;
				_waveCount++;
				
				StartCoroutine(SpawnEnemies((int) Mathf.Pow(_waveCount, 1.15f) + 1));
			}
		}

		_timeUntilWave -= Time.deltaTime;
	}

	IEnumerator SpawnEnemies(int count)
	{
		for (int i = 0; i < count; i++)
		{
			Instantiate(enemyPrefab, enemySpawn.position, Quaternion.identity);
			yield return new WaitForSeconds(0.2f);
		}
	}
}
