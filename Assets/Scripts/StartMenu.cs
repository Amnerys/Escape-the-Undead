using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean menuAction;

    public AudioSource audioPlay;
    public AudioClip introSong;
    public AudioClip messageAudio;

    void Start()
    {
        //audioPlay = GetComponent<AudioSource>();
        audioPlay.clip = introSong;
        audioPlay.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetMenuDown())
        {
            print("Menu" + handType);
            LoadGameScene();
            StartCoroutine(ChangeAudio());
        }
    }

    public bool GetMenuDown()
    {
        return menuAction.GetLastStateDown(handType);
    }

    public void LoadGameScene()
    {        
        StartCoroutine(LoadAfterTimer());
    }

    private IEnumerator LoadAfterTimer()
    {
        // the reason we use a coroutine is simply to avoid a quick "flash" of the 
        // loading screen by introducing an artificial minimum load time
        yield return new WaitForSeconds(10.0f);

        SceneManager.LoadScene("Game");
    }

    public void StopSound()
    {
        audioPlay.Stop();
    }

    public IEnumerator ChangeAudio()
    {
        StopSound();
        yield return new WaitForSeconds(0.05f);
        audioPlay.clip = messageAudio;
        audioPlay.Play();
    }
}