using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public ButtonPart3D buttonPart3D_Mouse;
    public ButtonPart3D buttonPart3D_Keyboard;
    public UnityEvent onActivate;

    private void Update() {
        if(buttonPart3D_Keyboard.isActive && buttonPart3D_Mouse.isActive){
            onActivate.Invoke();
        }
    }

}
