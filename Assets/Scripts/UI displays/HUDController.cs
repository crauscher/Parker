using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    // config parameters
    public Queue<string> messages = new Queue<string>();

    // state variables
    [SerializeField] float timeDelay = 5.0f;
    private bool isPosting = false;

    // component references
    [SerializeField] GameObject MessagePanel;
    [SerializeField] TextMeshProUGUI MessageText;

    void Start()
    {
        AddMessageToQueue("Welcome to Parker");
        AddMessageToQueue("Have fun, earn tips!!");
    }
    void Update()
    {
        if (!isPosting && messages.Count > 0)
        {
            isPosting = true;
            StartCoroutine(PostMessages());
        }
    }

    IEnumerator PostMessages()
    {
        MessagePanel.SetActive(true);
        var txt = messages.Dequeue();
        MessageText.text = txt;
        //Debug.Log("Processing: " + txt);
        yield return new WaitForSeconds(timeDelay);
        isPosting = false;
        MessagePanel.SetActive(false);
    }

    // public methods
    public void AddMessageToQueue(string txt)
    {
        //Debug.Log("Now in AddMessageToQueue.");
        messages.Enqueue(txt);
        //Debug.Log("Message #"+messages.Count+" added.");
    }
}
