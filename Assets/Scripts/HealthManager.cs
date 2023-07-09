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
        EventBus.Instance.OnFail.AddListener(() => LoseHealth());
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Tab)) LoseHealth();
    }


    public void LoseHealth()
    {
        health--;
        if (health <= 0)
        {
            EventBus.Instance.OnGameOver.Invoke();
            GameManager.Instance.HandleToMenu();
            health = maxHealth;
            //Tisch umwerfen wenn tod
        }
    }


}
