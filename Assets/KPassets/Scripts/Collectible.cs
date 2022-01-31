using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public float pickUpDistance = 1.5f;
    public GameObject player;

    public float distance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //scan to see the distance
            distance = Vector3.Distance(transform.position, player.transform.position);

            //if distance < pickUpDistance do something
            if (distance < pickUpDistance)
            {
                //TODO:send the data to inventory



                //destroy the object
                Destroy(gameObject);

            }
        }
    }

}
