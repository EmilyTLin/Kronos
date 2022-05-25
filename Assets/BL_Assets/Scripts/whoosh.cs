using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whoosh : MonoBehaviour
{
    private bool storyStarted = false;
    private bool audioPlayed = false;
    void Update()
    {
        
        if (!storyStarted && DialogueManager.Instance.sip())
        {
            storyStarted = true;
        }

        if (storyStarted && !audioPlayed && !DialogueManager.Instance.sip())
        {
            audioPlayed = true;
            FindObjectOfType<AudioManager>().Play("time machine sound");
        } 
    }
}
