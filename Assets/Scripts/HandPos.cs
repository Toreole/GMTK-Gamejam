using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPos : MonoBehaviour
{
  public Transform Hand_R;
  public Transform Hand_L;

  void Update() {
    Hand_R.transform.position = transform.position + InputTracking.GetLocalPosition(XRNode.RightHand);
    Hand_L.transform.position = transform.position + InputTracking.GetLocalPosition(XRNode.LeftHand);

    Hand_R.transform.rotation = InputTracking.GetLocalRotation(XRNode.RightHand);
    Hand_L.transform.rotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
  }
}
