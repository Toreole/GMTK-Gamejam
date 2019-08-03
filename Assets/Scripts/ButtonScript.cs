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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(handTag))
        {
            animator.SetBool(clickBool, true);
            print("collided with hand");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        StopAllCoroutines();
        StartCoroutine(DelayUp()); 
    }

    IEnumerator DelayUp()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool(clickBool, false);
    }
}
