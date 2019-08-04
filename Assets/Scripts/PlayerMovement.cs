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

    [SerializeField, Header("Non XR Head Movement only:")]
    protected float stepLength = 0.5f;
    [SerializeField]
    protected AnimationCurve headMoveCurve;
    [SerializeField]
    protected float moveAmount;

    float traveledDistance;
    Vector3 lastPosition;
    Vector3 cameraBaseOffset;

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
            cameraBaseOffset = camera.position - transform.position;
        }
    }

    //fetch input
    void Update()
    {
        GetInput();
        if (isXR)
        {
            MovementXR();
        }
        else //keyb and mouse 
        {
            Movement();
            HeadMove();
        }
    }

    void MovementXR()
    {
        var deltaTime = Time.deltaTime;
        var rotation = (isXR ? rotationSpeedXR : rotationSpeed) * deltaTime;

        //try to get the normalized forward
        var forward = camera.forward * movZ;
        forward.y = 0;
        if (forward.sqrMagnitude > Mathf.Epsilon)
            forward.Normalize();
        //try to get the normalized right
        var right = camera.right * movX;
        right.y = 0;
        if (right.sqrMagnitude > Mathf.Epsilon)
            right.Normalize();

        var movement = forward + right;
        movement.Normalize();
        movement *= walkSpeed * deltaTime;

        agent.Move(movement);
        //rotation for both
        transform.Rotate(0, yRotIn * rotation, 0);
    }

    void Movement()
    {
        var deltaTime = Time.deltaTime;
        var rotation = (isXR ? rotationSpeedXR : rotationSpeed) * deltaTime;
        //rotation up and down, camera
        var xRot = -xRotIn * rotation;
        var deltaXRot = Mathf.Clamp(xRot, minXRot - currentXRot, maxXRot - currentXRot);
        currentXRot += deltaXRot;
        camera.Rotate(deltaXRot, 0, 0);
        //rotation left to right

        var movement = (movX * transform.right + movZ * transform.forward).normalized * deltaTime * walkSpeed;
        agent.Move(movement);
        transform.Rotate(0, yRotIn * rotation, 0);
    }

    void HeadMove()
    {
        traveledDistance += Vector3.Distance(lastPosition, transform.position);
        float t = Mathf.Clamp((traveledDistance % stepLength) / stepLength, 0, 1);
        float yOff = headMoveCurve.Evaluate(t) * moveAmount;
        camera.position = transform.position + cameraBaseOffset + Vector3.up * yOff;
        //set for next cycle
        lastPosition = transform.position;
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
