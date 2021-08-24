using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyNumberScript : MonoBehaviour
{

    Text KeyDisplay;
    public static int key = -88;

    // Start is called before the first frame update
    void Start()
    {
        KeyDisplay = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        KeyDisplay.text = ("Key " + key);
    }
}
