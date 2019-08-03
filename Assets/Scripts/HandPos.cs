using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPos : MonoBehaviour
{
  private Vector3 originalPos;
  public Transform Hand_R;
  public Transform Hand_L;

  void Start() {
    originalPos = transform.position;
  }

  void Update() {
    Hand_R.transform.position = originalPos + InputTracking.GetLocalPosition(XRNode.RightHand);
    Hand_L.transform.position = originalPos + InputTracking.GetLocalPosition(XRNode.LeftHand);

    Hand_R.transform.rotation = InputTracking.GetLocalRotation(XRNode.RightHand);
    Hand_L.transform.rotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
  }
}
