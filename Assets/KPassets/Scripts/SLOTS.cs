using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLOTS : MonoBehaviour
{

    public GameObject item;

    public int ID;
    public string type;
    public string description;
    public Text dialogtext;
    public bool empty;
    public Sprite icon;
    public GameObject txtbox;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void displayDescription()
    {
        if (txtbox.activeInHierarchy)
        {
            txtbox.SetActive(false);
            dialogtext.text = description;
            txtbox.SetActive(true);
        }
        else
        {
            txtbox.SetActive(true);
            dialogtext.text = description;
        }
    }

    // Update is called once per frame
    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }


}
