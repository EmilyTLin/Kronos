using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextScene: MonoBehaviour
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

        if ( distance < 2.1f && Input.GetKeyDown("space"))
        {
            int y = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(y+1);
        }
    }
}
