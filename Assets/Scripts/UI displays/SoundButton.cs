using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundButton : MonoBehaviour
{
    public bool soundMuted = true;
    private GameObject obj, winObj;
    private Text buttonText, winText;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 0; // muted
        obj = GameObject.Find("SoundButtonText");
        buttonText = obj.GetComponent<Text>();
        
        //winObj = GameObject.Find("WinText");  // Keep in mind this will be in a different scene
        //winText = winObj.GetComponent<Text>();

        //Debug.Log("buttonText: " + buttonText);
        //Debug.Log("winText: " + winText);           // Is in the "Thanks" scene, not the "Level01" scene

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
	{
        
        if (soundMuted) {
            AudioListener.volume = 1;
            soundMuted = false;

            buttonText.text = "Turn sound off";

        
        } else {
            AudioListener.volume = 0;
            soundMuted = true;

            buttonText.text = "Turn sound on";     
        }
    }

    public void OnQuitButtonPress()
    {
        SceneManager.LoadScene("Thanks");
        // winText.text = "Congratulations! You earned $" + TipsScript.Tips + " in tips.";
    }
}
