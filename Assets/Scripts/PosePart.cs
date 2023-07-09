using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PosePart : MonoBehaviour
{
    public Vector3 fixed_rotation;
    public ControllerType type;
    public bool isHit = false;

    public float threshold = 0.05f;
    public int rotation;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.TryGetComponent<Controller>(out Controller controller) == false) return;
        if (controller.type != type) return;
        if (Vector3.Distance(other.transform.parent.position, transform.position) > threshold) return;
        if (type == ControllerType.KEYBOARD && controller.rotation != rotation) return;
        
        isHit = true;


    }

    private void OnTriggerExit(Collider other)
    {
        isHit = false;
    }

    public void SetRotation(int rot)
    {
        rotation = rot;
        transform.rotation = Quaternion.Euler(fixed_rotation.x, rotation * 30f, fixed_rotation.z);
    }
}
