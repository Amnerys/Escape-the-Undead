using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    private float waitTime = 4f;
    public static Text scoreText;

    // Use this for initialization
    void Start () {
        scoreText = GetComponent<Text>();
        StartCoroutine(ScoreText());
    }

    IEnumerator ScoreText()
    {
        scoreText.text = "Don't fear the dead, they just seek help";
        yield return new WaitForSeconds(waitTime);
        // Deactivate scoreboard after 5 seconds
        if (scoreText.gameObject.activeInHierarchy == true)
            scoreText.gameObject.SetActive(false);
    }
}
