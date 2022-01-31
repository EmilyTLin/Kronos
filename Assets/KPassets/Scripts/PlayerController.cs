using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //idk why i introduce variables here
    public Vector2 speed = new Vector2(10, 7);
    Vector3 movement;
    public float xVelocity;
    public float yVelocity;
    private Inventory inventory;


    private void Awake()
    {
        inventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        //WASD keypresses
        xVelocity = Input.GetAxis("Horizontal");
        yVelocity = Input.GetAxis("Vertical");

        //dash go brrrr
        if (Input.GetKeyDown("left shift"))
        {
            speed = new Vector2(20, 14);
        }
        else if (Input.GetKeyUp("left shift"))
        {
            speed = new Vector2(10, 7);
        }

        //character flips on left/right movement
        if (xVelocity < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //move player
        movement = new Vector3(speed.x * xVelocity, speed.y * yVelocity , 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);


    }
}
