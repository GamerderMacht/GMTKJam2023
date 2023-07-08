using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPart3D : MonoBehaviour
{
    public bool isActive = false;
    public ControllerType type;

    private void OnTriggerStay(Collider other)
    {
        isActive = false;
        Controller controller = null;
        other.transform.parent.TryGetComponent<Controller>(out controller);
        // Debug.Log(controller);
        if (controller == null) { isActive = false; return; }
        if (type != controller.type) { isActive = false; return; }

        isActive = Vector3.Distance(transform.position, other.transform.position) < 0.1f;
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = false;
    }

    float GetDistance()
    {
        return 0f;
    }
}
