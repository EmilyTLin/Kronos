using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YellowSmokeMovement : MonoBehaviour
{
    private float Radius = 0.3f;

    private Vector2 center;
    private float angle;
    private float angleUpdate;

    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        center = transform.position;
        angleUpdate = -0.008f;
    }

    // Update is called once per frame
    void Update()
    {
        angle = angle + angleUpdate;
        var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * Radius;

        transform.position = center + offset;
    }
}
