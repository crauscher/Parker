using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{



    public static double TipsValue = 99.00;
    Text score;

    public static int LevelValue = 1;
    public static int DamageValue = 0;
    public static int CarsRemaining = 4;

    public static string minutesString = "00";
    public static string secondsString = "00";

    //    private float timeRemaining = 5000;
        private float timeLeft = 299;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> ();   

    }

    // Update is called once per frame



    void Update()
    {
       // Debug.Log( "TimeRemaining: " + timeRemaining);

        if (timeLeft > 0)
          {
               timeLeft -= Time.deltaTime;
          }
          else
          {
              Debug.Log("Time has run out!");
              timeLeft = 0;
          }
        
        float minutes = Mathf.Floor(timeLeft/60);
        float seconds = Mathf.RoundToInt(timeLeft % 60);
     

        if (minutes < 10) {
            minutesString = "0" + minutes.ToString();
        } 
        else minutesString = minutes.ToString();

        if (seconds < 10) {
            secondsString = "0" + seconds.ToString();
        }
        else secondsString = seconds.ToString();

       // score.text = " Level " + LevelValue + " - Tips: $" + TipsValue + 
        //  " - Damage: " + DamageValue +"% - Cars remaining: " + CarsRemaining;
          
         // timer.Text ="Timer: " + minutesString + ":" + secondsString;



        
    }

}
