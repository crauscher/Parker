using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages player's active targeting status

public class ItemFocus : MonoBehaviour
{
    // config parameters
    [SerializeField] public int itemID;
    [SerializeField] public int startingSlotID;

    // state variables
    [SerializeField] bool isFocus;

    // cached references
    [SerializeField] private ObjectValue CamFocus;
    private LotConfig lc;
    private ItemAnim ia;

    void Awake()
    {
        lc = FindObjectOfType<LotConfig>();
        ia = GetComponent<ItemAnim>();
    }
    void Start() 
    { 
        ParkSelf();
    }
    void Update()
    {
        CheckFocusStatus();
    }

    // private methods
    private void CheckFocusStatus()
    {
        var focusID = CamFocus.value.GetComponent<ItemFocus>().GetItemID();
        if (itemID == focusID)
        {
            isFocus = true;
        }
        else
        {
            isFocus = false;
        }
    }

    // public methods
    public int GetItemID() 
    { 
        return itemID;
    }
    public int GetStartingSlotID() 
    { 
        return startingSlotID; 
    }
    public bool GetFocusStatus() 
    { 
        return isFocus; 
    }
    public void ParkSelf()
    {
        var slot = lc.GetSlot(startingSlotID);
        transform.position = slot.transform.position;
        var slotfacing = slot.gameObject.GetComponent<SlotConfig>().GetSlotOrientation();
        ia.InitializeFacing(slotfacing);
    }
}