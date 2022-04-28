using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class MainMenu : MonoBehaviour
	{
		public Button startButton, exitButton;

		public void Start()
		{
			startButton.onClick.AddListener(() => EnterGame());
			exitButton.onClick.AddListener(() => ExitGame());
		}

		public void EnterGame()
		{
			SceneManager.LoadScene(1);
		}

		public void ExitGame()
		{
			Application.Quit();
		}
	}
}
