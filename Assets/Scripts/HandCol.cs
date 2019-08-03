using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCol : MonoBehaviour
{
  public void OnCollisionEnter(Collision col) {
    if (col.collider.gameObject.tag == "Button") {
      col.collider.gameObject.GetComponent<ButtonScript>().Activate();
    }
  }
}
