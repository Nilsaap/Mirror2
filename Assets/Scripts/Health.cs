using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;

public class Health : NetworkBehaviour
{
    public float playerHealth;
    public Image Bar;
    public Text text;
    public GameObject player;
    public Scene deathScene;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = playerHealth / 100;
        text.text = playerHealth.ToString();
        
    }
    public void takeDamage(float damage)
    {
       playerHealth -= damage;
        if (playerHealth <= 0)
        {
            NetworkClient.Shutdown();
            SceneManager.LoadScene("Death Scene");
            
        }
    }
}
