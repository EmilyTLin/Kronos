using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caralarm : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("car alarm");
    }

    private void Update()
    {

    }
}
