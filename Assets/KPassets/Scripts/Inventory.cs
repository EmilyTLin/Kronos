using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public static Inventory instance;

    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    public bool triggerEntered;
    private GameObject itemPickedUp;
    void Awake()
    {
        //inventory = GameObject.FindWithTag("Inventory");
        //slotHolder = GameObject.FindWithTag("Slots");
    }


    void Start()
    {

        allSlots = 25;
        enabledSlots = 25;
        slot = new GameObject[allSlots];
        triggerEntered = false;

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<SLOTS>().item == null)
            {
                slot[i].GetComponent<SLOTS>().empty = true;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }

        if (Input.GetKeyDown("space") 
            && triggerEntered)
        {
            if (itemPickedUp.tag == "Item")
            {
                Debug.Log("found an item");

                //GameObject itemPickedUp = other.gameObject;
                Item item = itemPickedUp.GetComponent<Item>();

                AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
                triggerEntered = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEntered = true;
        itemPickedUp = other.gameObject;
        /*
        if (Input.GetKeyDown("space"))
        {
            if (other.tag == "Item")
            {
                Debug.Log("found an item");

                GameObject itemPickedUp = other.gameObject;
                Item item = itemPickedUp.GetComponent<Item>();

                AddItem(itemPickedUp, item.ID, item.type, item.description, item.icon);
            }
        }
        */
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerEntered = false;
    }

    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<SLOTS>().empty)
            {
                //add item to slot
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<SLOTS>().item = itemObject;
                slot[i].GetComponent<SLOTS>().icon = itemIcon;
                slot[i].GetComponent<SLOTS>().type = itemType;
                slot[i].GetComponent<SLOTS>().ID = itemID;
                slot[i].GetComponent<SLOTS>().description = itemDescription;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<SLOTS>().UpdateSlot() ;
                slot[i].GetComponent<SLOTS>().empty = false;
                return;
            }

        }
    }

}
