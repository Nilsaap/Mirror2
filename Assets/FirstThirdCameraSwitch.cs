using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThirdCameraSwitch : MonoBehaviour
{
    public Transform firstperson_loc;
    public Transform thirdperson_loc;
    public Transform mainCamera;
    public float lerpSpeed = 3;

    private bool disableOnce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!disableOnce)
            {
                mainCamera.GetComponent<PlayerFollow>().enabled = false;
                mainCamera.SetParent(transform);
                GetComponent<PlayerController>().currentMode = mode.firstperson;
                disableOnce = true;
            }
            if (Vector3.Distance(mainCamera.position, firstperson_loc.position) > .1f)
            {
                mainCamera.position = Vector3.MoveTowards(mainCamera.position, firstperson_loc.position, lerpSpeed * Time.deltaTime);
            }
            else
            {
                mainCamera.position = firstperson_loc.position;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (disableOnce)
            {
                mainCamera.GetComponent<PlayerFollow>().enabled = true;
                mainCamera.SetParent(null);
                disableOnce = false;
                GetComponent<PlayerController>().currentMode = mode.thirdperson;
                gameObject.transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
            }
            if (Vector3.Distance(mainCamera.position, thirdperson_loc.position) > .1f)
            {
                mainCamera.position = Vector3.MoveTowards(mainCamera.position, thirdperson_loc.position, lerpSpeed * Time.deltaTime);
            }
            else
            {
                mainCamera.position = thirdperson_loc.position;
            }
        }
    }
}
