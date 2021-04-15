using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{
    public ParticleSystem muzzelFlash;
    public Camera cam;
    public float damage;
    public float range = 100f;
    public float explosionForce = 50;
    public float explosionRadius = 50;
    public bool canShoot;
    public Image crosshair;
    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        crosshair.gameObject.SetActive(false);
        model = transform.GetChild(0).gameObject;
        crosshair.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<PlayerController>().currentMode == mode.firstperson)
        {
            canShoot = true;
            crosshair.gameObject.SetActive(true);
            model.gameObject.SetActive(true);
        }
        else
        {
            canShoot = false;
            crosshair.gameObject.SetActive(false);
            model.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            shoot();

            muzzelFlash.Play();
        }

    }


    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            Health tareget;
            if (tareget = hit.transform.GetComponent<Health>())
            {
                tareget.GetComponent<Health>().takeDamage(damage);
            }

            if (hit.transform.gameObject.GetComponent<Rigidbody>())
            {
                hit.transform.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce * 100, hit.point, explosionRadius);
            }

        }
    }
}