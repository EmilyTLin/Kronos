 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{

    [SerializeField]
    private TextAsset inkJSONAsset;

    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.Instance.StartStory(inkJSONAsset);
    }
}
