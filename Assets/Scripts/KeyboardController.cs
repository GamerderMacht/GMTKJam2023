using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    void Update()
    {
        // Debug.Log(constraints);
        MoveObject();
        RotateObject();
        
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

    void RotateObject()
    {
        if (Input.GetMouseButton(0) && transform.rotation.y >= -maxRotationValue)
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);

        }
        if (Input.GetMouseButton(1) && transform.rotation.y <= maxRotationValue)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        }

        ClampRotation();

    }

    private void ClampRotation()
    {
        Vector3 keyboardEulerAngles = transform.rotation.eulerAngles;

        keyboardEulerAngles.y = (keyboardEulerAngles.y > 180) ? keyboardEulerAngles.y - 360 : keyboardEulerAngles.y;
        keyboardEulerAngles.y = Mathf.Clamp(keyboardEulerAngles.y, -maxRotationValue, maxRotationValue);

        transform.rotation = Quaternion.Euler(keyboardEulerAngles);
    }


}
