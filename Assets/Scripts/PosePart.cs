using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosePart : MonoBehaviour
{
    public ControllerType type;
    public bool isHit = false;

    public float threshold = 0.05f;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.TryGetComponent<Controller>(out Controller controller))
        {
            if (controller.type == type)
                if (Vector3.Distance(other.transform.parent.position, transform.position) < threshold)
                    isHit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isHit = false;
    }
}
