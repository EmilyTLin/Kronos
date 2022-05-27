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

    // ActiveBox: Left = 0; Right = 1; Unknown = 2
    private int activeBox = 0;

    [Range(0, 0.05f)]
    [SerializeField]
    private float textDelay;

    //[SerializeField]
    //private Canvas canvas;

    //[SerializeField]
    //private TextAsset inkJSONAsset;


    [SerializeField]
    private TextMeshProUGUI leftSpeaker;

    [SerializeField]
    private Image leftPortrait;

    [SerializeField]
    private TextMeshProUGUI rightSpeaker;

    [SerializeField]
    private Image rightPortrait;

    [SerializeField]
    private TextMeshProUGUI unknownSpeaker;


    [SerializeField]
    private TextMeshProUGUI speech;

    [SerializeField]
    private GameObject choiceBox;

    // UI Prefabs
    [SerializeField]
    private Button buttonPrefab;
    //private TextMeshProUGUI buttonPrefab;


    /*
     * THE FOLLOWING DECLARATIONS ARE TEMPORARY
     * FOR THE DEMO (because I don't know how
     * to reference asset paths through code lol)
     */

    [SerializeField]
    private Texture2D kronos_1;

    /*
     * END OF TEMPORARY DECLARATIONS
     */

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

    public bool sip()  //created a getter so i can use storyInProgress it to queue sound (bruce 5/24/2022)
    {
        return storyInProgress;
    }

    // Start is called before the first frame update
    // Only use for testing purposes.
    void Start()
    {
        leftSpeaker.transform.parent.gameObject.SetActive(false);
        rightSpeaker.transform.parent.gameObject.SetActive(false);
        unknownSpeaker.transform.parent.gameObject.SetActive(false);
        speech.transform.parent.gameObject.SetActive(false);

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

        //if(!focusLeft) rightSpeaker.transform.parent.gameObject.SetActive(true);
        //else leftSpeaker.transform.parent.gameObject.SetActive(true);

        speech.transform.parent.gameObject.SetActive(true);

        speech.color = Color.black;
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

        if (activeBox == 1)
        {
            leftSpeaker.transform.parent.gameObject.SetActive(false);
            rightSpeaker.transform.parent.gameObject.SetActive(true);
            unknownSpeaker.transform.parent.gameObject.SetActive(false);

            if (i > 0)
            {
                rightSpeaker.text = message.Substring(0, i);
                message = message.Substring(i).Trim(charsToTrim);
            }
            else
            {
                rightSpeaker.text = "System";
            }


            if (rightSpeaker.text == "System")
            {
                rightSpeaker.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                rightSpeaker.transform.parent.gameObject.SetActive(true);
            }
        }

        else if (activeBox == 2)
        {
            leftSpeaker.transform.parent.gameObject.SetActive(false);
            rightSpeaker.transform.parent.gameObject.SetActive(false);
            unknownSpeaker.transform.parent.gameObject.SetActive(true);

            if (i > 0)
            {
                unknownSpeaker.text = message.Substring(0, i);
                message = message.Substring(i).Trim(charsToTrim);
            }
            else
            {
                unknownSpeaker.text = "System";
            }


            if (unknownSpeaker.text == "System")
            {
                unknownSpeaker.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                unknownSpeaker.transform.parent.gameObject.SetActive(true);
            }
        }

        else
        {
            leftSpeaker.transform.parent.gameObject.SetActive(true);
            rightSpeaker.transform.parent.gameObject.SetActive(false);
            unknownSpeaker.transform.parent.gameObject.SetActive(false);

            if (i > 0)
            {
                leftSpeaker.text = message.Substring(0, i);
                message = message.Substring(i).Trim(charsToTrim);
            }
            else
            {
                leftSpeaker.text = "System";
            }


            if (leftSpeaker.text == "System")
            {
                leftSpeaker.transform.parent.gameObject.SetActive(false);
            }
            else
            {
                leftSpeaker.transform.parent.gameObject.SetActive(true);
            }
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
        leftSpeaker.transform.parent.gameObject.SetActive(false);
        rightSpeaker.transform.parent.gameObject.SetActive(false);
        unknownSpeaker.transform.parent.gameObject.SetActive(false);
        speech.transform.parent.gameObject.SetActive(false);
    }

    // Handle cases of tags in story file
    private void ParseTags()
    {
        // Set default tag values first
        SetTextColor("black");

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
                case "align":
                    if(param == "right")
                    {
                        activeBox = 1;
                    }
                    else if(param == "unknown")
                    {
                        activeBox = 2;
                    }
                    else
                    {
                        activeBox = 0;
                    }
                    break;
                case "face":
                    SetPortrait(param);
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
                //speech.color = Color.cyan;
                speech.color = new Color(0, 0, 0.8f);
                break;
            case "green":
                //speech.color = Color.green;
                speech.color = new Color(0, 0.8f, 0);
                break;
            case "black":   // Same as default case
                speech.color = Color.black;
                break;
            case "white":
                speech.color = Color.white;
                break;
            default:
                speech.color = Color.black;
                break;
        }
    }

    /*
     * THE FOLLOWING CODE IS TEMPORARY
     * FOR THE DEMO (because I don't know how
     * to reference asset paths through code lol)
     */

    // Face tag
    private void SetPortrait(string portrait)
    {
        switch (portrait)
        {
            case "col1_yay":
                if (activeBox == 1)
                {
                    //rightPortrait.sprite.LoadImage();
                    rightPortrait.sprite = Resources.Load<Sprite>("Assets/Sprites/col1_yay");
                }
                else
                {
                    //leftPortrait;
                }
                break;
            default:
                activeBox = 2;
                break;
        }
        
    }

    /*
     * END OF TEMPORARY DECLARATIONS
     */

}
