using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : Controller
{
    void Update()
    {
        MoveObject();
        

    }

    private void MoveObject()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.Translate(movement * speed * Time.deltaTime);
        transform.position += movement * speed * Time.deltaTime;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -constraints.x, constraints.x),
            0f,
            Mathf.Clamp(transform.position.z, -constraints.y, constraints.y)
        );
    }

   
}
