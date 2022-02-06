using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_DialogueBox : MonoBehaviour
{
    public GameObject dbox;
    // Start is called before the first frame update
    void Start()
    {
         //Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Destroy(gameObject);
        }
    }

    /*private void OnMouseDown()
    {
        //this doesnt work idk why
        Destroy(gameObject);
    }*/
}

