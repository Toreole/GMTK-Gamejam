using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    protected string xMovAxis, zMovAxis;
    [SerializeField]
    protected string xRotAxis, yRotAxis;
    [SerializeField]
    protected new Transform camera;
    [SerializeField]
    protected NavMeshAgent agent;
    [SerializeField]
    protected float walkSpeed, rotationSpeed;

    [SerializeField]
    protected HandPos handPos;
    [SerializeField]
    protected ResetCameraVR camReset;

    protected bool isXR = false;

    //disable XR related stuff when this isnt XR
    void Awake()
    {
        isXR = XRDevice.isPresent;

        if (isXR)
        {

        }
        else
        {
            handPos.Disable();
            camReset.enabled = false;
        }
    }

    //fetch input
    void Update()
    {
        print(Input.GetAxis("Horizontal"));
        if(isXR)
        {

        }
        else
        {

        }
    }
}
