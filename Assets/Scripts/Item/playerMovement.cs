using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thing to check for: Why does the orientation not stay in the direction of movement?


public class playerMovement : MonoBehaviour
{
    // config parameters
    [SerializeField] public float minSpeed = 0.03f;
    [SerializeField] private float maxSpeed = 1.0f;
    [SerializeField] private float moveOffset = 0.5f;

    // state variables
    [SerializeField] private float moveSpeed;

    // cached references
    private Rigidbody2D rb;
    private playerController pc;
    private playerAnim pa;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<playerController>();
        pa = GetComponent<playerAnim>();
    }

    private void Start()
    {
        moveSpeed = maxSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            moveAvatar();
    }

    private void moveAvatar()
    {
        var change = GetInput();

        var moveH = change.x * moveSpeed;
        var moveV = change.y * moveSpeed * moveOffset;

        rb.velocity = new Vector2(moveH, moveV);
    }

    public Vector2 GetInput()
    {
        var changeH = Input.GetAxis("Horizontal");
        var changeV = Input.GetAxis("Vertical");

        return new Vector2(changeH, changeV);
    }
    
}
