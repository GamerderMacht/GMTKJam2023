using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VfxScript : MonoBehaviour
{

    public VisualEffect vfx;

    public void Play(bool success)
    {
        Debug.Log("success "+success);
        vfx.SetBool("success", success);
        vfx.Play();
    }
}
