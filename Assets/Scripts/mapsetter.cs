using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapsetter : MonoBehaviour
{
    public networklobbymanagerext networklobbymanagerext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setmapsnow()
    {
        networklobbymanagerext.GameplayScene = "Snow";
    }

    public void setmaplevelone()
    {
        networklobbymanagerext.GameplayScene = "level 1";
    }

}
