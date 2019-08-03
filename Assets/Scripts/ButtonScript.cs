using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    protected string handTag = "Hand";
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected string clickTrigger = "Click";


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(handTag))
        {
            animator.SetTrigger(clickTrigger);
            print("collided with hand");
        }
    }
}
