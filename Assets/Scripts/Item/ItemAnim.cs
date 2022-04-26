using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    // config parameters
    private string[] directions = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };

    // state variables
    public string facing;
    public bool isFlashing;

    // cached references
    private Animator anim;
    private ItemFocus focus;
    private ItemMovement movement;

    void Awake()
    {
        anim = GetComponent<Animator>();
        focus = GetComponent<ItemFocus>();
        movement = GetComponent<ItemMovement>();
    }
    void Start() {}
    void Update()
    {
        bool _isFocus = focus.GetFocusStatus();
        if (_isFocus)
        {
            Vector2 _moveinput = movement.GetMoveInput();
            SetFacing(_moveinput);
            checkLights();
            UpdateAnimation(_moveinput);
        }
    }

    // private methods

    private void SetFacing(Vector2 input)
    {
        float _minSpeed = movement.GetMinSpeed();
        if (input.magnitude >= _minSpeed)  // avatar is idle
        {
            facing = DirectionToIndex(input);
        }
    }
    private string DirectionToIndex(Vector2 input)
    {
        Vector2 _norDir = input.normalized; // returns magnitude of 1
        float _step = 360 / 8;
        float _offset = _step / 2;
        float _angle = Vector2.SignedAngle(Vector2.up, _norDir); // Vector2(from, to)

        _angle += _offset;
        if (_angle < 0)
        {
            _angle += 360;
        }

        int _stepCount = Mathf.FloorToInt(_angle / _step);  // counterclockwise slice by 8
        return directions[_stepCount];
    }
    private void checkLights()
    {
        bool lightswitch = movement.GetJump(); 
        
        if (lightswitch && !isFlashing)
        {
            anim.SetBool("isFlashing", true);
         //   Debug.Log("Lights are on.");
            isFlashing = true;
        }
        else if (lightswitch && isFlashing)
        {
            anim.SetBool("isFlashing", false);
         //   Debug.Log("Lights are off.");
            isFlashing = false;
        }
    }
    private void UpdateAnimation(Vector2 input)
    {
        if (input != Vector2.zero)
        {
            anim.SetFloat("changeX", input.x);
            anim.SetFloat("changeY", input.y);
            anim.SetBool("isMoving", true);
          //  Debug.Log("Item is moving.");
        }
        else
        {
            anim.SetBool("isMoving", false);
           // Debug.Log("Item not moving.");
        }
    }

    // public methods
    public void InitializeFacing(string facing)
    {
        Vector2 _impulse;
        var empty = 0.0f;
        var half = 0.7f;
        var full = 1.0f;

        switch (facing)
        {
            case "N":
                _impulse = new Vector2(empty, full);
                break;
            case "NW":
                _impulse = new Vector2(-half, half);
                break;
            case "W":
                _impulse = new Vector2(-full, empty);
                break;
            case "SW":
                _impulse = new Vector2(-half, -half);
                break;
            case "SE":
                _impulse = new Vector2(half, -half);
                break;
            case "E":
                _impulse = new Vector2(full, empty);
                break;
            case "NE":
                _impulse = new Vector2(half, half);
                break;
            default:
                _impulse = new Vector2(empty, -full);
                break;
        }
        UpdateAnimation(_impulse);
        UpdateAnimation(Vector2.zero);
    }
}
