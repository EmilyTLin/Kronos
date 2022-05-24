using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // using text mesh for the clock display

using UnityEngine.Rendering; // used to access the volume component

public class DayNightScript : MonoBehaviour
{
    public Volume ppv; // this is the post processing volume
    public int dayStage = 1;


    public bool activateLights; // checks if lights are on
    public GameObject[] lights; // all the lights we want on when its dark
    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dayStage == 2)
            {
                dayStage = 1;
            }
            else
            {
                dayStage = 2;
            }
            ControlPPV();
        }

    }

    public void ControlPPV() // used to adjust the post processing slider.
    {
        ppv.weight = 0;
        if (dayStage == 2) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            ppv.weight = 1; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 

            if (activateLights == false) // if lights havent been turned on
            {

                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].SetActive(true); // turn them all on
                }
                activateLights = true;

            }
        }


        if (dayStage == 1) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            ppv.weight = 0;

            if (activateLights == true) // if lights are on
            {

                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].SetActive(false); // shut them off
                }
                activateLights = false;

            }
        }
    }
}
