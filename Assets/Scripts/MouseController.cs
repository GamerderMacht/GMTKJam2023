using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : Controller
{
    
    
    

    
    //Movementscript für die maus
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);

        transform.position = new Vector3
        (Mathf.Clamp(transform.position.x, -constrainX, constrainX),
        0f,
        Mathf.Clamp(transform.position.z, -constrainZ, constrainZ));
        
            
                
            
        
    }
}
