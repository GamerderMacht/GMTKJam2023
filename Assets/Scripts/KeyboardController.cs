using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    void Update()
    {
        // Debug.Log(constraints);
        MoveObject();
    }

    private void MoveObject()
    {
        transform.position = ReturnMousePosition();
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -constraints.x, constraints.x),
            0f,
            Mathf.Clamp(transform.position.z, -constraints.y, constraints.y)
        );

        // Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.down * 10, Color.red, 10); 
    }

    private Vector3 ReturnMousePosition()
    {
        Vector3 result = new Vector3(0, 0, 0);
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
