using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotConfig : MonoBehaviour
{
    // config parameters
    [SerializeField] private int slotID = 0;
    [SerializeField] sectionEnum slotSection;
    [SerializeField] orientationEnum slotOrientation;
    [SerializeField] roleEnum slotRole;

    // state variables
    [SerializeField] private bool isTaken;

    // cached references

    // private methods
    // public methods
    public int GetSlotID() 
    { 
        return slotID; 
    }
    public string GetSlotSection() 
    { 
        return slotSection.ToString();
    }
    public string GetSlotOrientation() 
    {
        return slotOrientation.ToString();
    }
    public string GetSlotRole() 
    { 
        return slotRole.ToString(); 
    }
    public void ToggleTaken() 
    { 
        isTaken = !isTaken; 
    }
    public bool CheckTaken() 
    { 
        return isTaken; 
    }
}
