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
    public bool empty;
    public Sprite icon;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }
}
