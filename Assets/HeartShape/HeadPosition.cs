using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class HeadPosition : MonoBehaviour
{

    //For use with the Vive mainly. Probably can adapt it for other uses too though.
    //This script is to keep rotations of the player and camera (head) synced. Also eventually (soon™) auto-rotation functionality will be implemented.

    private GameObject CameraEye;
    private GameObject CameraRig;
    private GameObject Player;

    private Quaternion HMDLocalRotation; //Current position of HMD.
    private Quaternion HMDHomeForward; //This is the location that the HMD should be in when it is facing the monitor or forward.
    private Quaternion HMDLeftTurnLimit;
    private Quaternion HMDRightTurnLimit;

    public SteamVR_Camera steamCam; //Put the Steam Camera in here.

    void Start()
    {
        CameraEye = GameObject.Find("steamCam");
        //CameraRig = GameObject.Find("[CameraRig]");
        //Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Player.transform.forward = CameraEye.transform.forward;
        //CameraRig.transform.position = Player.transform.position;

        AutoRotate();
    }

    void AutoRotate()
    {
        HMDLocalRotation = steamCam.head.localRotation;
        Debug.Log(HMDLocalRotation.eulerAngles);

        if (Input.GetKeyDown("g"))
        {
            HMDHomeForward = HMDLocalRotation;
            Debug.Log("Home/Forward position set to: " + HMDHomeForward);
        }
        if (Input.GetKeyDown("h"))
        {
            HMDLeftTurnLimit = HMDLocalRotation;
            Debug.Log("Left Turn Limit position set to: " + HMDLeftTurnLimit);
        }
        if (Input.GetKeyDown("j"))
        {
            HMDRightTurnLimit = HMDLocalRotation;
            Debug.Log("Right Turn Limit position set to: " + HMDRightTurnLimit);
        }


    }
}