using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    public static DialogueManager Instance { get { return _instance; } }

    private char[] charsToTrim = { ' ', ':' };
    private Story story;
    private List<string> tagList;
    private bool storyInProgress = false;
    private bool choiceSelected = true;

    [Range(0, 0.05f)]
    [SerializeField]
    private float textDelay;

    //[SerializeField]
    //private Canvas canvas;

    //[SerializeField]
    //private TextAsset inkJSONAsset;

    [SerializeField]
    private TextMeshProUGUI speaker;

    [SerializeField]
    private TextMeshProUGUI speech;

    [SerializeField]
    private GameObject choiceBox;

    // UI Prefabs
    [SerializeField]
    private Button buttonPrefab;
    //private TextMeshProUGUI buttonPrefab;

    // I don't understand this yet I copy/pasted it lol
    // Pretty sure it has to do with preventing duplicate singletons
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    // Only use for testing purposes.
    void Start()
    {
        //StartStory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && storyInProgress)
        {
            if (!story.canContinue && story.currentChoices.Count == 0)
            {
                TerminateDialogue();
            }

            if (story.canContinue)
            {
                RefreshView();

            }

            CheckForChoices();

        }
    }

    // This function will be called when another object requests that
    // a new dialogue should start.
    public void StartStory(TextAsset storyFile)
    {
        story = new Story(storyFile.text);
        storyInProgress = true;
        Debug.Log("Successfully loaded dialogue");

        speaker.transform.parent.gameObject.SetActive(true);
        speech.transform.parent.gameObject.SetActive(true);

        speech.color = Color.white;
        RefreshView();
        CheckForChoices();
    }

    // Call this function to display the next line of dialogue
    private void RefreshView()
    {
        Debug.Log("Displaying the next message");
        string message = story.Continue();
        ParseTags();

        int i = message.IndexOf(":");
        if (i > 0)
        {
            speaker.text = message.Substring(0, i);
            message = message.Substring(i).Trim(charsToTrim);
        }
        else
        {
            speaker.text = "System";
        }

        if (speaker.text == "System")
        {
            speaker.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            speaker.transform.parent.gameObject.SetActive(true);
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(message));
        //speech.text = message;  // Remove after implementing TypeSentence
    }

    // If the story needs a choice to progress, will display choices
    private void CheckForChoices()
    {
        if (story.currentChoices.Count != 0 && choiceSelected)
        {
            choiceSelected = false;
            StartCoroutine(ShowChoices());
        }
    }

    // Should create a new menu displaying choices (selected using arrow keys)?
    // nvm, selected using mouse for now
    // Will use UnityUI buttons until we figure out what to do in kronos
    // Trying to use TextMeshPro instead of buttons somehow
    IEnumerator ShowChoices()
    {
        Debug.Log("Listing the " + story.currentChoices.Count + " available options");

        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];
            Button button = Instantiate(buttonPrefab, choiceBox.transform);
            //TextMeshProUGUI button = Instantiate(buttonPrefab, choiceBox.transform);

            button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
            //button.text = choice.text;

            
            button.onClick.AddListener(delegate
            {
                SelectChoice(choice);
            });
            
        }

        choiceBox.SetActive(true);

        yield return new WaitUntil(() => { return choiceSelected; });
    }

    // Player selected an option, update the story and clean up the choiceBox
    private void SelectChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);

        choiceSelected = true;
        choiceBox.SetActive(false);

        int count = choiceBox.transform.childCount;
        for (int i = count - 1; i >= 0; i--)
        {
            Destroy(choiceBox.transform.GetChild(i).gameObject);
        }

        RefreshView();
    }

    // Spells out dialogue character at a time
    IEnumerator TypeSentence(string sentence)
    {
        speech.text = "";
        foreach (char letter in sentence)
        {
            speech.text += letter;
            yield return new WaitForSeconds(textDelay);
        }
        yield return null;
    }

    // End of dialogue reached, update story and disable all dialogue-related UI
    private void TerminateDialogue()
    {
        Debug.Log("Dialogue terminated");

        storyInProgress = false;
        speaker.transform.parent.gameObject.SetActive(false);
        speech.transform.parent.gameObject.SetActive(false);
    }

    // Handle cases of tags in story file
    private void ParseTags()
    {
        tagList = story.currentTags;    // Should tagList be declared here instead?
        foreach (string tag in tagList)
        {
            string prefix = tag.Split(' ')[0];
            string param = tag.Split(' ')[1];

            switch (prefix.ToLower())
            {
                case "color":
                    SetTextColor(param);
                    break;
                // Any other tags? (Portrait expressions, sprite expressions, sound effects)
                default:
                    break;
            }
        }
    }

    // Color tag
    private void SetTextColor(string color)
    {
        switch (color)
        {
            case "blue":
                speech.color = Color.cyan;
                break;
            case "green":
                speech.color = Color.green;
                break;
            case "white":   // Same as default case
                speech.color = Color.white;
                break;
            default:
                speech.color = Color.white;
                break;
        }
    }
}
