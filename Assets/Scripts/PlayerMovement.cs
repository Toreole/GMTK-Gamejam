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
    protected string xRotXRAxis;
    [SerializeField]
    protected float rotationSpeedXR = 60f;
    [SerializeField]
    protected float minXRot, maxXRot;
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
    [SerializeField]
    protected GameObject playerInteract;

    protected bool isXR = false;
    
    protected float currentXRot = 0f;

    //Input
    float movX, movZ;
    float xRotIn, yRotIn;

    //disable XR related stuff when this isnt XR
    void Awake()
    {
        isXR = XRDevice.isPresent;
        if (isXR)
        {
            print(XRDevice.model);
            playerInteract.SetActive(false);
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
        var deltaTime = Time.deltaTime;
        var rotation = (isXR? rotationSpeedXR : rotationSpeed) * deltaTime;

        GetInput();
        if (isXR)
        {
            //try to get the normalized forward
            var forward = camera.forward * movZ;
            forward.y = 0;
            if (forward.sqrMagnitude > Mathf.Epsilon)
                forward.Normalize();
            //try to get the normalized right
            var right = camera.right * movX;
            right.y = 0;
            if(right.sqrMagnitude> Mathf.Epsilon)
                right.Normalize();

            var movement = forward + right;
            movement.Normalize();
            movement *= walkSpeed * deltaTime;

            agent.Move(movement);

        }
        else //keyb and mouse 
        {
            //rotation up and down, camera
            var xRot = -xRotIn * rotation;
            var deltaXRot = Mathf.Clamp(xRot, minXRot - currentXRot, maxXRot - currentXRot);
            currentXRot += deltaXRot;
            camera.Rotate(deltaXRot, 0, 0);
            //rotation left to right

            var movement = (movX * transform.right + movZ * transform.forward).normalized * deltaTime * walkSpeed;
            agent.Move(movement);
        }
        //rotation for both
        transform.Rotate(0, yRotIn * rotation, 0);
    }

    void GetInput()
    {
        movX = Input.GetAxis(xMovAxis);
        movZ = Input.GetAxis(zMovAxis);

        if (isXR)
        {
            yRotIn = Input.GetAxis(xRotXRAxis);
        }
        else
        {
            //Only for mouse input, no rotation with XR
            xRotIn = Input.GetAxis(xRotAxis);
            yRotIn = Input.GetAxis(yRotAxis);
        }
    }
}
