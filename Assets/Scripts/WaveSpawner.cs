using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
	[Header("Numeric Modifiers")]
	public int totalWaves;
	public float waveDelay = 5.0f;
	
	[Header("Object References")]
	public GameObject enemyPrefab;
	public Transform enemySpawn;

	[Header("UI Fields")] 
	public TMP_Text waveCounter;
	public TMP_Text waveTimer;

	public bool active;

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
		active = !Dialogue.IsEnabled;
		
		if (active)
		{
			if (_timeUntilWave <= 0)
			{
				if (_waveCount < totalWaves || totalWaves == 0)
				{
					_timeUntilWave = waveDelay;
					_waveCount++;
				
					StartCoroutine(SpawnEnemies((int) Mathf.Pow(_waveCount, 1.05f) + 1));
				}
			}

			_timeUntilWave -= Time.deltaTime;
		}

		String waves = (totalWaves > 0) ? totalWaves.ToString() : "∞";
		waveCounter.text = $"Wave: {_waveCount} / {waves}";
		waveTimer.text = $"Next wave in: {Mathf.RoundToInt(_timeUntilWave)} sec(s)";
	}

	IEnumerator SpawnEnemies(int count)
	{
		for (int i = 0; i < count; i++)
		{
			Instantiate(enemyPrefab, enemySpawn.position, Quaternion.identity);
			yield return new WaitForSeconds(0.4f);
		}
	}
}