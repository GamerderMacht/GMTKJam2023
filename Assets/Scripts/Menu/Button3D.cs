using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public PosePart buttonPart3D_Mouse;
    public PosePart buttonPart3D_Keyboard;
    
    public UnityEvent onActivate;

    private void Update() {
        if(buttonPart3D_Keyboard.isHit && buttonPart3D_Mouse.isHit){
            onActivate.Invoke();
        }
    }

}
