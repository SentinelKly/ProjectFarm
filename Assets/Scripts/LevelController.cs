using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
	public Sprite generalSprite;
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
			
			Speaker general = new Speaker()
			{
				name = "general",
				dialogue = "You done fucked up! | I am higher than a kite and I can do better!",
				icon = generalSprite
			};

			var dialogue = GetComponent<Dialogue>();
			dialogue.ResetDialogue();
			dialogue.AddSpeaker(general);
			Dialogue.IsEnabled = true;

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