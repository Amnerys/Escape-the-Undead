using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedBalls : MonoBehaviour {

    public float lifetime = 0.5f;
    public float ROTATION_SPEED = 60f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, ROTATION_SPEED * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Use Destroy() to delete the key after for example 0.5 seconds
        Destroy(gameObject, lifetime);
    }
}
