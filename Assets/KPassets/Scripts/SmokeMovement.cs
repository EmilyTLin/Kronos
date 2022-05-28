using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SmokeMovement : MonoBehaviour
{
    private float Radius = 0.5f;

    private Vector2 center;
    private float angle;
    private float angleUpdate;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        center = transform.position;
        angleUpdate = (float) (rand.NextDouble() * 0.01 + 0.01);
    }

    // Update is called once per frame
    void Update()
    {
        angle = angle + angleUpdate;
        var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;

        transform.position = center + offset;
    }
}
