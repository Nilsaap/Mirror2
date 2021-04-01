using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_in : MonoBehaviour
{
    public GameObject model;
    public Transform me;
    public GameObject publicVehicle;
    public bool isRiding;
    public float number = 0.888f;
    public Camera cam_two;
    // Start is called before the first frame update
    void Awake()
    {
        cam_two.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isRiding)
        {
            model.gameObject.SetActive(true);
            publicVehicle.transform.SetParent(null);
            me.transform.position = new Vector3(me.position.x + 5, me.position.y, me.position.z);
            isRiding = false;
            cam_two.gameObject.SetActive(false);

        }
        if (isRiding)
        {
            publicVehicle.transform.position = new Vector3(0, publicVehicle.transform.position.y, 0);
            ride();
        }
    }

    public void goIn(GameObject vehicle)
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        vehicle.transform.SetParent(me);
        publicVehicle = vehicle;
        isRiding = true;
        cam_two.gameObject.SetActive(true);
    }
    void ride()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        model.gameObject.SetActive(false);
        publicVehicle.transform.position = new Vector3(me.position.x, me.position.y - number, me.position.z);

    }
}
