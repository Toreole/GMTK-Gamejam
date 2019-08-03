﻿using System.Collections;
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
        GetInput();
        if(isXR)
        {

        }
        else //keyb and mouse
        {
            //rotation up and down, camera
            var rotation = rotationSpeed * deltaTime;
            var xRot = -xRotIn * rotation;
            var deltaXRot = Mathf.Clamp(xRot, minXRot - currentXRot, maxXRot - currentXRot);
            currentXRot += deltaXRot;
            camera.Rotate(deltaXRot, 0, 0);
            //rotation left to right
            transform.Rotate(0, yRotIn * rotation, 0);

            var movement = (movX * transform.right + movZ * transform.forward).normalized * deltaTime * walkSpeed;
            agent.Move(movement);
        }
    }

    void GetInput()
    {
        movX = Input.GetAxis(xMovAxis);
        movZ = Input.GetAxis(zMovAxis);

        //Only for mouse input, no rotation with XR
        xRotIn = Input.GetAxis(xRotAxis);
        yRotIn = Input.GetAxis(yRotAxis);
    }
}