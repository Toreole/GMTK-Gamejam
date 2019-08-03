using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPos : MonoBehaviour
{
  public Transform Hand_R;
  public Transform Hand_L;
  public Transform Head;

  public float CameraHeight;

  void Start() {
    UpdateHeight();
  }

  public void UpdateHeight() {
    CameraHeight = Head.position.y;
  }

  void Update() {
    Hand_R.transform.position = transform.position + InputTracking.GetLocalPosition(XRNode.RightHand) + new Vector3(0f, CameraHeight, 0f);
    Hand_L.transform.position = transform.position + InputTracking.GetLocalPosition(XRNode.LeftHand) + new Vector3(0f, CameraHeight, 0f);

    Hand_R.transform.rotation = InputTracking.GetLocalRotation(XRNode.RightHand);
    Hand_L.transform.rotation = InputTracking.GetLocalRotation(XRNode.LeftHand);
  }

  public void Disable() {
    Hand_R.gameObject.SetActive(false);
    Hand_L.gameObject.SetActive(false);
    this.enabled = false;
  }
}
