using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GripCameraTurn : MonoBehaviour {

    public SteamVR_Input_Sources handType; // The type of hand(s) to poll for input.
    public SteamVR_Action_Boolean gripAction; // Reference to the TurnCamera action.

    private float speed = 0.5f;
    public GameObject playerCamera;
    private Quaternion leftTurn;

    // Use this for initialization
    void Start()
    {
        leftTurn = Quaternion.FromToRotation(Vector3.forward, Vector3.left);
    }

    // Update is called once per frame
    void Update () {
        if (GetGripDown())
        {
            print("Grip" + handType);

            // Rotate camera around parent object 45 degrees.
            playerCamera.transform.localPosition = Quaternion.RotateTowards(Quaternion.identity, leftTurn, 45) * playerCamera.transform.localPosition;
            // Point the camera at the parent object (assuming up is always in the positive y axis direction)
            playerCamera.transform.localRotation = Quaternion.LookRotation(playerCamera.transform.localPosition * -1, Vector3.up);

            TurnCamera();
        }
    }

    public bool GetGripDown()
    {
        return gripAction.GetLastStateDown(handType);
    }

    void TurnCamera()
    {
        playerCamera.transform.eulerAngles = Vector3.Lerp(playerCamera.transform.eulerAngles, new Vector3(90, 0, 0), Time.deltaTime * speed);
        print("TurnCamera called");
    }
}
