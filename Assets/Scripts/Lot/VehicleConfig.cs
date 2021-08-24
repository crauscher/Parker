using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleConfig : MonoBehaviour
{
    // config parameters
    [SerializeField] GameObject ClientCars;
    public List<Transform> clientcars = new List<Transform>();

    // state variables

    // cached references
    private LotConfig lc;
    private SlotConfig sc;

    private void Awake()
    {
        lc = FindObjectOfType<LotConfig>();
        sc = FindObjectOfType<SlotConfig>();
    }

    void Start()
    {
        CountClientCars();
    }
    void CountClientCars()
    {
        foreach (Transform t in ClientCars.transform)
        {
            clientcars.Add(t);
        }
    }

    // public methods

    public Transform GetCar(int num) { return null; }
    public Transform WhereIsCar(int num) { return null; }
}
