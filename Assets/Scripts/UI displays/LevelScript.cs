using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour


{

    Text levelDisplay;

    public static int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        levelDisplay = GetComponent<Text> ();   
    }

    // Update is called once per frame
    void Update()
    {
        // levelDisplay.text = "Hey! You are on level " + currentLevel + "!";
        levelDisplay.text = "Level: " + currentLevel;
    }
}
