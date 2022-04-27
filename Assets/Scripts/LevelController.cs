using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
	public Slider healthSlider;
	public WaveSpawner spawner;
	public bool dialogueOnLoad;
	
	private float _health = 100f;

	public void DealDamage(float damage)
	{
		_health -= damage;

		healthSlider.value = _health / 100f;
		
		if (_health <= 0f)
		{
			spawner.ResetWaveSpawner();

			_health = 100f;
			healthSlider.value = 1f;
		}
	}

	private void Start()
	{
		healthSlider.value = _health / 100f;
		Dialogue.IsEnabled = dialogueOnLoad;
	}
}