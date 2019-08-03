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
    protected string clickBool = "Click";
    [SerializeField]
    protected float stayTime = 0.2f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(handTag))
        {
            Activate(true); 
            print("collided with hand");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        StopAllCoroutines();
        StartCoroutine(DelayUp()); 
    }

    public void Activate(bool playerIsXR)
    {
        animator.SetBool(clickBool, true);
        if (!playerIsXR)
            StartCoroutine(DelayUp());
    }

    IEnumerator DelayUp()
    {
        yield return new WaitForSeconds(stayTime);
        animator.SetBool(clickBool, false);
    }
}
