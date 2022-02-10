using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //public Scoreboard scoreBoard;
    public Keys keys;
    public AudioSystem audioSystem;
    public Text scoreText;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        //- Deactivate scoreboard is active
        if (scoreText.gameObject.activeInHierarchy == true)
            scoreText.gameObject.SetActive(false);
    }    
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnTriggerEnter(Collider other)
    {
        Door door = GameObject.FindObjectOfType<Door>();
        if (other.gameObject.CompareTag("key"))
        {
            //- ... play sound ...
            Keys.GetComponent<PlaySound>().Play();

            for (int i = 0; i < Keys.keys.Count; i++)
            {
                //- ... destroy other gameObject and remove index
                Destroy(other.gameObject);
                if (Keys.keys[i] == null)
                    Keys.keys.RemoveAt(i);
            }

            //- activate score board
            scoreText.gameObject.SetActive(true);

            //- Toggle Score Canvas
            StartCoroutine(ScoreText(5f));
        }

        if (other.gameObject.CompareTag("door"))
        {
            door.LoadStartScreen();
        }
    }

    IEnumerator ScoreText(float waitTime)
    {
        switch (Keys.keys.Count)
        {
            case 6:
                scoreText.text = "5 keys are left";
                break;
            case 5:
                scoreText.text = "4 keys are left";
                break;
            case 4:
                scoreText.text = "3 keys are left";
                break;
            case 3:
                scoreText.text = "2 keys are left";
                break;
            case 2:
                scoreText.text = "1 key is left";
                break;
            case 1:
                scoreText.text = "No keys left to be taken.\nTouch the door to leave";
                break;
        }
        yield return new WaitForSeconds(waitTime);

        //- Deactivate scoreText after 5 seconds
        if (scoreText.gameObject.activeInHierarchy == true)
            scoreText.gameObject.SetActive(false);
    }
}
