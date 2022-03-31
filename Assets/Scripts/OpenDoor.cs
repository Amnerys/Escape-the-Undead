using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

    public GameObject door;
    private AudioSource audioSource;

    public AudioClip doorOpeningClip;
    public AudioClip doorLockedClip;

    private bool locked = true;
    private bool opening = false;
    public static OpenDoor Instance;
    public float waitTime = 1f;
    public Text scoreText;

    // Use this for initialization
    void Start ()
    {
        // Get a reference to the audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        // Use 'opening' to check if the door is opening...
        if (opening)
        {
            // Get to the Start Scene            
            //SceneManager.LoadScene(sceneName: "Title Scene");
            StartCoroutine(ReloadScene());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        door = GameObject.Find("Door");
        /// Called when the 'Door' game object is clicked
        /// - Plays an audio clip when the door starts opening

        // Prints to the console when the method is called
        //Debug.Log("'Door.OnDoorClicked()' was called");

        if (KeyPickUp.keys == 5)
        {
            Unlock();     
        
        }

        // If the door is unlocked, start animating the door rotating open and play a sound to indicate the door is opening
        if (!locked)
        {
            // ... start the action defined in Update() by changing the value of 'opening'
            opening = true;
            // ... use 'audioSource' to play the AudioClip assigned to the AudioSource component
            audioSource.clip = doorOpeningClip;
            audioSource.Play();         
        }

        // Play a different sound if the door is locked
        else
        {
            audioSource.clip = doorLockedClip;
            audioSource.Play();
        }
    }

    public void Unlock()
    {
        //Debug.Log("'Door.Unlock()' was called");
        locked = false;
    }

    public IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName: "Title Scene");
    }
}
