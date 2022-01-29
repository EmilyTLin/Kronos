using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 speed = new Vector2(10, 0);
    Vector3 movement;
    public float xVelocity;

    // Update is called once per frame
    void Update()
    {
        xVelocity = Input.GetAxis("Horizontal");

        if (xVelocity < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        movement = new Vector3(speed.x * xVelocity, speed.y * 0, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);


    }
}
