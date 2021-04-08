using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject targettodrown = other.gameObject;
            targettodrown.GetComponent<scriptwithwater>().waterPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject targettodrown = other.gameObject;
            targettodrown.GetComponent<PlayerController>().Speed = targettodrown.GetComponent<PlayerController>().Speed / 2;
            targettodrown.GetComponent<PlayerController>().runSpeed = targettodrown.GetComponent<PlayerController>().Speed / 2;
            targettodrown.GetComponent<scriptwithwater>().waterPanel.SetActive(false);
        }
    }
}
