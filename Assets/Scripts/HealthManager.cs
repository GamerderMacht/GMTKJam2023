using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)) LoseHealth();
    }


    public void LoseHealth()
    {
        EventBus.Instance.OnFail.Invoke();
        health--;
        if (health <= 0)
        {
            GameManager.Instance.HandleToMenu();
            health = maxHealth;
            //Tisch umwerfen wenn tod
        }
    }
    
    
}
