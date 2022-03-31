using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class FlashingText : MonoBehaviour
{

    Text flashingText;

    // Use this for initialization
    void Start()
    {
        // Get a reference to an existing TextMeshPro component or Add one if needed.
        //flashingText = GetComponent<Text>() ?? gameObject.AddComponent<Text>();
        //get the Text component
        flashingText = GetComponent<Text>();
        //Call coroutine BlinkText on Start
        StartCoroutine(BlinkText());
    }

    //function to blink the text 
    public IEnumerator BlinkText()
    {
        //blink it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //set the Text's text to blank
            flashingText.text = "";
            //display blank text for 0.5 seconds
            yield return new WaitForSeconds(.5f);
            //display “Press START (Menu)” for the next 0.5 seconds
            flashingText.text = "Press START (Menu)";
            yield return new WaitForSeconds(.5f);
        }
    }
}