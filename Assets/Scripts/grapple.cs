using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapple : MonoBehaviour
{
    public LayerMask isGrappleable;
    public float range = 100f;
    public Camera cam;
    public LineRenderer lr;
    private Vector3 grappleDestination;
    public float grappleSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, isGrappleable))
            {
                GetComponent<PlayerController>().enabled = false;
                grappleDestination = hit.point;

            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            GetComponent<PlayerController>().enabled = true;
            grappleDestination = Vector3.zero;
        }
        if(Input.GetButton("Fire1"))
        {
            
            if(grappleDestination != Vector3.zero)
            {
                if(Vector3.Distance(transform.position, grappleDestination) < 2)
                {
                    GetComponent<PlayerController>().enabled = true;
                    grappleDestination = Vector3.zero;
                }
                else {
                    transform.position = Vector3.MoveTowards(transform.position, grappleDestination, grappleSpeed * Time.deltaTime);
                }
                
            }
        }

        

    }
}
