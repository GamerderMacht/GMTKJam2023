using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{

    
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
        transform.position = ReturnMousePosition();
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -constrainX, constrainX),
        0f,
        Mathf.Clamp(transform.position.z, -constrainZ, constrainZ));       

        // Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.down * 10, Color.red, 10); 
    }

    private Vector3 ReturnMousePosition()
    {
        Vector3 result = new Vector3(0,0,0); 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                result = hit.point;
            }
        }
                
        return result;
    }
}
