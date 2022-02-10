using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class AudioSystem : MonoBehaviour {

    public static AudioSystem instance = null;

    public AudioClip keyAudio;
    public AudioClip undead;
    public AudioClip scarecrow;

    private PlaySound playSound;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().name == "Intro Scene")
        {
            playSound = GetComponent<PlaySound>();
            playSound.PlayLooping();
        }
    }
}
