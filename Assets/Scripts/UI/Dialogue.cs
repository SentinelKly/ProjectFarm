using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	[Serializable]
	public class Speaker
	{
		public Sprite icon;
		public string name;
	
		[TextArea(5,20)]
		public string dialogue;
	}

	public class Dialogue : MonoBehaviour
	{
		[Header("Setup Controls")]
		public GameObject dialoguePanel;
		public float textSpeed;
	
		public static bool IsEnabled;

		[Header("Speaker Index")]
		public Speaker[] speakers;

		private TMP_Text _dialogueText, _dialogueSpeaker;
		private Image _dialogueIcon;
	
		private int _speakerIndex , _dialogueIndex;
		private bool _isWaiting, _isNewSpeaker;
		private float _typeCountdown;

		public void AddSpeaker(Speaker speaker)
		{
			speakers = new Speaker[1];
			speakers[0] = speaker;
		
			_dialogueIcon.sprite  = speakers[_speakerIndex].icon;
			_dialogueSpeaker.text = speakers[_speakerIndex].name;
		}
	
		public void ResetDialogue()
		{
			speakers           = Array.Empty<Speaker>();
			_dialogueText.text = "";
			_isNewSpeaker      = false;
			_isWaiting         = false;
			_speakerIndex      = 0;
			_dialogueIndex     = 0;
		}

		private void Start()
		{
			_dialogueIcon    = dialoguePanel.FindComponentInChildWithTag<Image>("DialogueImage");
			_dialogueSpeaker = dialoguePanel.FindComponentInChildWithTag<TMP_Text>("DialogueSpeaker");
			_dialogueText    = dialoguePanel.FindComponentInChildWithTag<TMP_Text>("DialogueText");
		
			dialoguePanel.SetActive(IsEnabled);

			_dialogueIcon.sprite  = speakers[_speakerIndex].icon;
			_dialogueSpeaker.text = speakers[_speakerIndex].name;
			_dialogueText.text    = "";
		}

		private void Update()
		{
			if (!IsEnabled) return;
		
			if (!dialoguePanel.activeSelf)
				dialoguePanel.SetActive(IsEnabled);

			if (!CheckForPause()) return;
			UpdateDialogue();
		}

		private void SwitchSpeaker()
		{
			if (_speakerIndex < speakers.Length - 1)
			{
				_speakerIndex++;
				_dialogueIcon.sprite = speakers[_speakerIndex].icon;
				_dialogueSpeaker.text = speakers[_speakerIndex].name;
				_dialogueIndex = 0;
			}
		
			_isNewSpeaker = false;
		}

		private bool CheckForPause()
		{
			if (_isWaiting && Input.GetKeyDown(KeyCode.Space))
			{
				if (_isNewSpeaker && _speakerIndex >= speakers.Length - 1)
				{
					IsEnabled = false;
					ResetDialogue();
					dialoguePanel.SetActive(false);
				}
			
				else 
					_dialogueText.text = "";

				_isWaiting = false;
				return false;
			}

			if (_isWaiting)
				return false;

			return true;
		}

		private void UpdateDialogue()
		{
			if (_typeCountdown <= 0f)
			{
				if (_isNewSpeaker)
					SwitchSpeaker();

				else if (_dialogueIndex < speakers[_speakerIndex].dialogue.Length)
				{
					char currentChar = speakers[_speakerIndex].dialogue[_dialogueIndex];

					if (currentChar == '|')
						_isWaiting = true;

					else if (currentChar == '\n')
						return;

					else
						_dialogueText.text += currentChar;

					_dialogueIndex++;
					_typeCountdown = 1f / textSpeed;
				}

				else
				{
					_isWaiting = true;
					_isNewSpeaker = true;
				}
			}

			_typeCountdown -= Time.deltaTime;
		}
	}
}