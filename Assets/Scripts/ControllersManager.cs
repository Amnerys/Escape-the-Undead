using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using VRTK;

public class ControllersManager : MonoBehaviour {

    public GameObject leftController;
    public GameObject rightController;
    public GameObject cameraEye;
    
    private CollectableManager collectableManager;
    private AudioSystem audioSystem;
    
    private ControllerInputManager leftControllerInputManager;
    private ControllerInputManager rightControllerInputManager;

    private VRTK_StraightPointerRenderer laserPointer;
    private VRTK_Pointer pointer;

    private Light spotlight;

    // Use this for initialization
    void Start () {
		
	}	
    
    public void SetupVariables()
    {
        if (SceneManager.GetActiveScene().name == "Fear")
        {
            //- find the controller manager script in each of the controllers...
            leftControllerInputManager = leftController.GetComponent<ControllerInputManager>();
            rightControllerInputManager = rightController.GetComponent<ControllerInputManager>();

            //- ...find and set the collectable manager component in each... 
            leftControllerInputManager.collectableManager = GameObject.FindObjectOfType<CollectableManager>();
            rightControllerInputManager.collectableManager = GameObject.FindObjectOfType<CollectableManager>();

            //- ... find and disable the scripts that control teleportation...
            laserPointer = GetComponentInChildren<VRTK_StraightPointerRenderer>();
            laserPointer.enabled = false;
            pointer = GetComponentInChildren<VRTK_Pointer>();
            pointer.enabled = false;

            //- ...find and set the sound manager in each...
            leftControllerInputManager.soundManager = GameObject.FindObjectOfType<SoundManager>();
            rightControllerInputManager.soundManager = GameObject.FindObjectOfType<SoundManager>();

            //- find and enable the spotlight in the cameraHead gameObject...
            spotlight = GetComponentInChildren<Light>();
            spotlight.enabled = true;

            //- ... enable them again later
            laserPointer.enabled = true;
            pointer.enabled = true;
        }
    }

}
