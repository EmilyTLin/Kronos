using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pile_interact : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    bool interacted;

    public GameObject MAIL;
    public GameObject COMIC;
    public GameObject NEWSPAPER;


    void Start()
    {
        interacted = false;
        Debug.Log("mail is spawning");
    }

    // Update is called once per frame
    void Update()
    {
        if (!interacted &&
            scanForProximity() &&
            Input.GetKeyDown("space"))
        {
            //spawn newspaper,comic and mail
            //Vector2 mailSpawn = this.transform.position + new Vector
            Instantiate(MAIL, this.transform.position + new Vector3(-0.5f, 0f, 0f), Quaternion.identity);
            Instantiate(NEWSPAPER, this.transform.position + new Vector3(-0.0f, +0.6f, 0f), Quaternion.identity);
            Instantiate(COMIC, this.transform.position + new Vector3(0.5f, -0.2f, 0f), Quaternion.identity);

            interacted = true;

            //destroy mail
            Destroy(this.gameObject);
        }

    }

    bool scanForProximity()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 0.8f) return true;
        return false;
    }
}
