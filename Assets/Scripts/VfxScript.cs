using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VfxScript : MonoBehaviour
{

    public VisualEffect vfx;


    private void Awake() {
        Destroy(this.gameObject, 1f);
    }

    public void Play(bool success)
    {
        vfx.SendEvent(success? "OnSuccess": "OnFail");
    }
}
