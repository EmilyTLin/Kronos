using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class simplyDialogue : MonoBehaviour
{
    public bool playerInRange;
    public bool eventTriggered = false;

    [SerializeField]
    private TextAsset inkJSONAsset;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && !eventTriggered)
        {
            if (inkJSONAsset != null)
                DialogueManager.Instance.StartStory(inkJSONAsset);
            else
                Debug.LogWarning("No Script Provided");

            eventTriggered = true;
        }
    }


    //protected override void OnCollide(Collider2D coll)
    //{
    //    if (coll.name == "player_0")
    //    {
    //        OnRead();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}