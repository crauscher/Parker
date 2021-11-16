using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

	//[SerializeField] GameObject SoundButtonText;

	public bool isMute = true;  // System should start muted
	

	void Start() {
		AudioListener.volume = 0;  // Sound should be off at the beginning
		isMute=true;
	}

	public void StartGame()
	{
		LevelScript.currentLevel = 1;
		CarsRemainingScript.currentCarsRemaining = 2;
		GoalScript.currentGoal = "Unknown";
		TipsScript.Tips = 0;
		SceneManager.LoadScene("Level-01");

	}

	public void Credits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void HelpScene()
	{
		SceneManager.LoadScene("HelpStart");
	}

	public void ReturnToStart()
	{
		SceneManager.LoadScene("HelpStart");
	}

	public void SoundButton()
	{
        
        if (isMute) {
            AudioListener.volume = 1;
            isMute = false;
            Debug.Log("Sound button clicked. System unmuted.");
		//	SoundButtonText.text = "Turn sound off.";
        
        } else {
            AudioListener.volume = 0;
            isMute = true;
            Debug.Log("Sound button clicked. System muted.");
		//	SoundButtonText.text = "Turn sound on.";
        }
	}
}
