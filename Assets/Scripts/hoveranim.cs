using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hoveranim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MO()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.20f, 0.20f, 1.20f);
    }
    public void ME()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.15f, 0.15f, 1.15f);
    }
    // private void OnMouseOver()
    //{
    //    Debug.Log("Hovering");
    //    gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.20f, 0.20f, 1.20f);
    // }
    // private void OnMouseExit()
    //{
    //    gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.15f, 0.15f, 1.15f);

    //}

}
