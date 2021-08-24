using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundButton : MonoBehaviour
{
    public bool soundMuted = true;
    private GameObject obj;
    private Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 0; // muted
        obj = GameObject.Find("SoundButtonText");
        buttonText = obj.GetComponent<Text>();
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
    }
}
