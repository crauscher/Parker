using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{
    //public methods
    public Vector2 GetInput()
    {
        var changeH = Input.GetAxis("Horizontal");
        var changeV = Input.GetAxis("Vertical");

        return new Vector2(changeH, changeV);
    }
    public bool GetFire1() 
    { 
        return Input.GetButton("Fire1"); 
    }       // left mouse / joystick
    public bool GetJump()  
    { 
        return Input.GetButton("Jump"); 
    }        // space button
    public bool GetSubmit() 
    { 
        return Input.GetButton("Submit"); 
    }     // enter button
    public bool GetCancel() 
    { 
        return Input.GetButton("Cancel"); 
    }      // escape button
}
