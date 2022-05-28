using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notSimplyDialogue : MonoBehaviour
{
    public bool playerInRange;
    public int rangeNum = 0;
    public bool eventTriggered = false;

    [SerializeField]
    public TextAsset inkJSONAsset0;
    [SerializeField]
    public TextAsset inkJSONAsset1;
    [SerializeField]
    public TextAsset inkJSONFlashback;
    [SerializeField]
    public TextAsset inkJSONAsset2;
    [SerializeField]
    public TextAsset inkJSONAsset3;

    public bool isInConversation = false;
    public bool firstConversation = true;
    public bool secondConversation = true;
    public int interactionCounter;
    public bool ifFlashback = false;

    void Start()
    {
        interactionCounter = 0;
    }


    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && !eventTriggered)
        {
            if (inkJSONAsset != null)
                DialogueManager.Instance.StartStory(inkJSONAsset);
            //interactionCounter++;
            else
                Debug.LogWarning("No Script Provided");

            eventTriggered = true;
        }
        */
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && firstConversation)
        {
            switch (interactionCounter)
            {
                case 0:
                    if (inkJSONAsset0 != null)
                    {
                        DialogueManager.Instance.StartStory(inkJSONAsset0);
                        interactionCounter++;
                    }
                    else
                        Debug.LogWarning("No Script Provided");
                    ifFlashback = false;
                    
                    break;
                case 1:
                    if (inkJSONFlashback != null && !DialogueManager.Instance.sip() && !ifFlashback)
                    {
                        //TODO: add flashback
                        DialogueManager.Instance.StartStory(inkJSONFlashback);
                        //ifFlashback = true;
                        interactionCounter++;

                    }
                    break;
                case 2:
                    if (inkJSONAsset1 != null && !DialogueManager.Instance.sip())
                    {
                        DialogueManager.Instance.StartStory(inkJSONAsset1);
                        interactionCounter++;
                        firstConversation = false;

                    }
                    break;
                default:
                    break;

            }
            //firstConversation = false;
            /*
            if(!ifFlashback)
            {
                if (inkJSONFlashback != null)
                {
                    DialogueManager.Instance.StartStory(inkJSONFlashback);
                }
                else
                    Debug.LogWarning("No Script Provided");
                ifFlashback = true;
            }
            */
        }

        else if(Input.GetKeyDown(KeyCode.Space) && playerInRange && rangeNum > 1 && secondConversation)
        {
            if (inkJSONAsset2 != null && !DialogueManager.Instance.sip())
            {
                DialogueManager.Instance.StartStory(inkJSONAsset2);
                secondConversation = false;
            }

        }

        else if(Input.GetKeyDown(KeyCode.Space) && playerInRange && rangeNum > 1 && !secondConversation)
        {
            if (inkJSONAsset3 != null && !DialogueManager.Instance.sip())
            {
                DialogueManager.Instance.StartStory(inkJSONAsset3);
                //secondConversation = false;
            }
        }

    }


    //protected override void OnCollide(Collider2D coll)
    //{
    //    if (coll.name == "player_0")
    //    {
    //        OnRead();
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
        rangeNum++;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }

    void OnConversationStart(Transform other)
    {
        isInConversation = true;
    }

    void OnConversationEnd(Transform other)
    {
        isInConversation = false;
    }
}
