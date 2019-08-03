using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCameraVR : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
      print(Input.GetAxis("OC_ResetCam"));
      //if (Input.GetAxis("OC_ResetCam")) {
      //  print("Yeet");
      //}
    }
}
