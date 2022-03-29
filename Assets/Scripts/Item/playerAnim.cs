using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    // config parameters
    private string[] directions = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };

    // state variables
    public string facing = "N";
    private Vector2 input;
    
    // cached references
    private Animator anim;
    private playerController pc;
    private playerMovement pm;

    void Start()
    {
        anim = GetComponent<Animator>();
        pc = GetComponent<playerController>();
        pm = GetComponent<playerMovement>();
    }

    private void Update()
    {
        input = pm.GetInput();
        SetFacing(input);
        Debug.Log("Updating player animation.");
        UpdateAnimation(input);
    }

    private void SetFacing(Vector2 _input)
    {
        if (_input.magnitude >= pm.minSpeed)  // avatar is idle
        {
            facing = DirectionToIndex(_input);
            Debug.Log("Player Anim Facing: " + facing);
        }
    }

    private string DirectionToIndex(Vector2 _input)
    {
        Vector2 norDir = _input.normalized; // returns magnitude of 1
        float step = 360 / 8;
        float offset = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, norDir); // Vector2(from, to)

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }

        int stepCount = Mathf.FloorToInt(angle / step);  // counterclockwise slice by 8
        return directions[stepCount];
    }

    public void UpdateAnimation(Vector2 _input)
    {
        Debug.Log("Player animation being updated.");
        if (_input != Vector2.zero)
        {
            anim.SetFloat("changeX", _input.x);
            anim.SetFloat("changeY", _input.y);
            anim.SetBool("isMoving", true);
            Debug.Log("Player is moving.");
        }
        else
        {
            anim.SetBool("isMoving", false);
            Debug.Log("Player is not moving.");
        }
    }
}
