using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ResetCameraVR : MonoBehaviour
{

  void Awake() {
    InputTracking.Recenter();
  }
}
