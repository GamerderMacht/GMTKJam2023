using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausMovement : MonoBehaviour
{
    [Header("Movement for Mouse with Keyboard Input")]
    
    public float speed;

    private Vector3 movement;
    //Movementscript für die maus
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        gameObject.transform.Translate(movement * speed * Time.deltaTime);
    }
}
