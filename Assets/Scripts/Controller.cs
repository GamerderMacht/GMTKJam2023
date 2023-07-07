using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector3 movement;
    public float speed;

    // public float constraint_x;
    // public float constraint_z;

    public Vector2 constraints;

    private void Awake() {
        constraints = GameObject.FindObjectOfType<Constants>().bounds;
    }
}
