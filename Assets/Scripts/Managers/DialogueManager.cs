using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

namespace Managers {
    public class DialogueManager : MonoBehaviour {
    
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject optionsParent;
        [SerializeField] private GameObject optionPrefab;
        [SerializeField] private GameObject continueButton;
    
        private Story _story;
        private static DialogueManager _instance;
        // Singleton. Check for existing _instance of the class
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError("There is already an _instance of DialogueManager in the scene");
            }
        }

        private void Start() {
            //_story = new Story(inkJSONAsset.text);
            dialoguePanel.SetActive(false);
        }

        public DialogueManager Instance { get; private set; }
    
        public void StartDialogue(TextAsset dialogue) {
            _story = new Story(dialogue.text);
            dialoguePanel.SetActive(true);
            DisplayNextSentence();
        }
    
        public void DisplayNextSentence() {
            Debug.Log(_story.canContinue);
            if (_story.canContinue) {
                string text = _story.Continue();
                dialogueText.text = text;
            
                // clear parent first.
                foreach (Transform child in optionsParent.transform) {
                    Destroy(child.gameObject);
                }
                // create button for each choice
                List<Choice> choices = _story.currentChoices;
                foreach (Choice choice in choices) {
                    GameObject button = Instantiate(optionPrefab, optionsParent.transform);
                    button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
                    button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate { _story.ChooseChoiceIndex(choice.index);
                        DisplayNextSentence();
                    });
                }
                // if there is no choce, display continue button.
                if (choices.Count == 0) {
                    continueButton.SetActive(true);
                } else {
                    continueButton.SetActive(false);
                }
            
            } else {
                ExitDialogue();
            }
        }
    
        public void ExitDialogue() {
            dialoguePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
