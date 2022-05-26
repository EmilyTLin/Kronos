using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLibrary : MonoBehaviour
{

    public GameObject player;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if ( distance < 0.7f && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
