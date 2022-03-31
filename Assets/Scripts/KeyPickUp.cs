using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUp : MonoBehaviour {

    public static int keys;
    public GameObject keyPoofPrefab;
    public Text scoreText;
    private OpenDoor doorOpen;
    public float lifeTime = 0.3f;
    public float waitTime = 2f;
    public KeyPickUp Instance;

    // Use this for initialization
    void Start () {
        keys = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (keys == 5)
        {
            doorOpen.Unlock();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        AddKeys();
        //print("total of keys " + keys);
        
        // Use Instantiate() to create a clone of the 'KeyPoof' prefab at this coin's position and with the 'KeyPoof' prefab's rotation
        Instantiate(keyPoofPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        // Use Destroy() to delete the key after for example 0.5 seconds
        Destroy(gameObject);        
    }

    IEnumerator FinalMessage(float waitTime)
    {
        //scoreText.gameObject.SetActive(true);
        scoreText.text = "The family's souls are freed, you may escape now.";
        yield return new WaitForSeconds(waitTime);
        // Deactivate scoreboard after 5 seconds
        if (scoreText.gameObject.activeInHierarchy == true)
            scoreText.gameObject.SetActive(false);
    }

    public void AddKeys()
    {
        keys++;

        if (keys == 5)
        {
            scoreText.gameObject.SetActive(true);
            StartCoroutine(FinalMessage(2f));            
        }
    }
}
