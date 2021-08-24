using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsScript : MonoBehaviour
{
    [SerializeField] private Text MessageDisplay;
    Text TipsDisplay;

    public static int Tips = 0;

    // Start is called before the first frame update
    void Start()
    {
        TipsDisplay = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Tips == 0)
        {
           MessageDisplay.text = "You haven't \nearned any \ntips yet,\n get to work!";
           // addMessageToQueue("You haven't \nearned any \ntips yet,\n get to work!");
        }
        else {
            MessageDisplay.text = "Awesome! You have $" + Tips + " in tips!";
           // addMessageToQueue("Awesome!You have $" + Tips + " in tips!");
        }
        TipsDisplay.text = "Tips :$ " + Tips;
    }

    public void addMessageToQueue(string message)
        {
        if (message != null) 
        {
            // call message script, add message string to array for display in sequence in central panel
        }
    }
}
