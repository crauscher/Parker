using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thing to check for: Why does the orientation not stay in the direction of movement?


public class ItemMovement : MonoBehaviour
{
    // config parameters
    [SerializeField] float minSpeed = 0.03f;
    [SerializeField] float maxSpeed = 1.0f;
    [SerializeField] float moveOffset = 0.5f;

    // state variables
    [SerializeField] float moveSpeed;

    // cached references
    private inputController ic;
    private Rigidbody2D rb;
    private ItemFocus focus;

    void Awake()
    {
        ic = FindObjectOfType<inputController>();
        rb = GetComponent<Rigidbody2D>();
        focus = GetComponent<ItemFocus>();
    }
    void Start()
    {
        moveSpeed = maxSpeed;
    }
    void FixedUpdate()
    {
        bool _isFocus = focus.GetFocusStatus();
        if (_isFocus)
        {
            movePlayer();
        }
    }

    // private methods
    private void movePlayer()
    {
        Vector2 _moveinput = GetMoveInput();

        float _moveH = _moveinput.x * moveSpeed;
        float _moveV = _moveinput.y * moveSpeed * moveOffset;

        rb.velocity = new Vector2(_moveH, _moveV);
    }

    // public methods
    public float GetMinSpeed() 
    { 
        return minSpeed;
    }
    public Vector2 GetMoveInput() 
    { 
        return ic.GetInput();
    }
}
