using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notSimplyDialogue : MonoBehaviour
{
    public bool playerInRange;
    public bool eventTriggered = false;

    [SerializeField]
    public TextAsset inkJSONAsset0;
    [SerializeField]
    public TextAsset inkJSONAsset1;
    [SerializeField]
    public TextAsset inkJSONFlashback;

    public bool isInConversation = false;
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
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && !eventTriggered)
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
                    //ifFlashback = false;
                    
                    break;
                case 1:
                    if (inkJSONFlashback != null && !DialogueManager.Instance.sip() && !ifFlashback)
                    {
                        //TODO: add flashback
                        DialogueManager.Instance.StartStory(inkJSONFlashback);
                        ifFlashback = true;
                    }
                    break;
                default:
                    break;
            }
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
