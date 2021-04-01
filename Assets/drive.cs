using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (Input.GetKeyDown(KeyCode.E))
        {
            other.GetComponent<get_in>().goIn(gameObject);
        }

    }
}
