using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undeads : MonoBehaviour {

    private AudioSource audioSource;
    private VariableSetup variableSetup;
    public AudioSystem audioSystem;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        variableSetup = GameObject.FindObjectOfType<VariableSetup>();
        variableSetup.SetupVariables();
    }

    // Use this for initialization
    void Start () {

        StartCoroutine(PlayZombieSound(10f));
    }

    IEnumerator PlayZombieSound(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (this.gameObject.CompareTag("zombie"))
        {
            audioSource.PlayOneShot(audioSystem.undead, 0.6f);
        }
        else if (this.gameObject.CompareTag("scarecrow"))
        {
            audioSource.PlayOneShot(audioSystem.scarecrow, 0.7f);
        }
    }
}
