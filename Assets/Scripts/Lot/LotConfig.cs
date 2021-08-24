using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotConfig : MonoBehaviour
{
    // config parameters
    [SerializeField] List<Transform> allSlots, paidSlots, valetSlots = new List<Transform>();
    Transform entrySlot, exitSlot;

    // state variables
    // cached references
    [SerializeField] GameObject ExitMarkerprefab;

    void Awake() 
    { 
        CountAllSlots(); 
    }
    void Start() 
    { 
        CountByRole();
        PlaceExitMarker();
    }

    // private methods
    void CountAllSlots()
    {
        foreach(Transform t in transform)
            {
                allSlots.Add(t);    
            }
    }
    void CountByRole()
    {
        for (int step = 0; step < allSlots.Count; step++)
        {
            var child = allSlots[step];
            var sc = child.gameObject.GetComponent<SlotConfig>();
            //sc.SetSlotID(step);

            var role = sc.GetSlotRole();
            switch (role)
            {
                case "ENTRY":
                    entrySlot = child.gameObject.transform;
                    break;
                case "EXIT":
                    exitSlot = child.gameObject.transform;
                    break;
                case "VALET":
                    valetSlots.Add(child.gameObject.transform);
                    break;
                case "PAID":
                    paidSlots.Add(child.gameObject.transform);
                    break;
                default:
                    break;
            }
        }
    }
    void PlaceExitMarker()
    {
        var marker = Instantiate(ExitMarkerprefab);
        marker.gameObject.transform.position = exitSlot.transform.position;
        marker.gameObject.transform.rotation = exitSlot.transform.rotation;
    }

    // public methods
    public Transform GetEntry() 
    { 
        return entrySlot; 
    }
    public Transform GetExit() 
    { 
        return exitSlot; 
    }
    public Transform GetSlot(int num) 
    {
        for (var _step = 0; _step <= allSlots.Count; _step++)
        {
            var sid = allSlots[_step].gameObject.GetComponent<SlotConfig>().GetSlotID();
            if (sid == num)
            {
                return allSlots[_step];
            }
        }
        return null;
    }
    public List<Transform> GetPaidSlots() 
    { 
        return paidSlots; 
    }
    public List<Transform> GetValetSlots() 
    { 
        return valetSlots; 
    }
}

public enum sectionEnum { FRONT, A1, A2, A3, A4, A5, B1, B2, C1, C2, D1, D2, D3, D4, D5, S1, S2, S3, S4, S5, S6, S7};
public enum roleEnum { EMPTY, VALET, PAID, ENTRY, EXIT };
public enum orientationEnum { N, NW, W, SW, S, SE, E, NE };