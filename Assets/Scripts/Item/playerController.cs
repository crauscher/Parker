using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // config parameters

    // state variables
    [SerializeField] public bool isActive;
    
    // cached references
    private playerMovement pm;
    private playerAnim pa;

    // Start is called before the first frame update
    void Awake()
    {
        pm = GetComponent<playerMovement>();
        pa = GetComponent<playerAnim>();
    }

    // Update is called once per frame
    void Start()
    {
        checkActiveTag();
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            checkIsActive();
        }
    }

    private void checkActiveTag()
    {
        if (gameObject.CompareTag("active"))
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    private void checkIsActive()
    {
        if (isActive)
        {
            gameObject.tag = "active";
            pa.enabled = true;
            pa.enabled = true;
            Debug.Log(gameObject.name + " is active.");
        }
        else
        {
            gameObject.tag = "idle";
            pa.enabled = false;
            pm.enabled = false;
            Debug.Log(gameObject.name + " is idle.");
        }
    }
}
