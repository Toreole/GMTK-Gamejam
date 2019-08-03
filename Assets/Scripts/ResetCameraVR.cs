﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ResetCameraVR : MonoBehaviour
{

  public HandPos handPos;

  void Awake() {
    InputTracking.Recenter();
  }

  // Update is called once per frame
  void Update()
  {
    print(Input.GetAxis("OC_ResetCam"));
    //if (Input.GetAxis("OC_ResetCam")) {
    //  print("Yeet");
    //}
    if (Input.GetAxis("OC_ResetCam") > 0)
    {
      InputTracking.Recenter();
      handPos.UpdateHeight();
    }
    //if (Input.GetAxis("Vive_ResetCam") > 0)
    //{
    //  InputTracking.Recenter();
    //}
  }
}
