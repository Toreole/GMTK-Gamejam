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
    protected float walkSpeed;

    protected bool isXR = false;

    //Destroy this if player is using XR, since this will conflict with it.
    void Start()
    {
        isXR = XRDevice.isPresent;

        if (isXR)
        {

        }
        else
        {

        }
    }

    //fetch input
    void Update()
    {
        if(isXR)
        {

        }
        else
        {

        }
    }
}
