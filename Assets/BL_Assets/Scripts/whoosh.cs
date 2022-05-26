using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(switchScene());
            
        } 
    }

    IEnumerator switchScene()
    {
        yield return new WaitForSeconds(5);
        FindObjectOfType<AudioManager>().Play("car alarm");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
