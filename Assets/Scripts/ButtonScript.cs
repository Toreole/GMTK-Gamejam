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
    protected float stayTime = 0.4f, stayTimeXR = 0.2f;
    [SerializeField]
    protected new AudioSource audio;
    [SerializeField]
    protected AudioClip pressSound, releaseSound;
    [SerializeField]
    protected Activatable targetActivate;
    
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
        StartCoroutine(DelayUp(stayTimeXR)); 
    }

    public void Activate(bool playerIsXR)
    {
        animator.SetBool(clickBool, true);
        if (!playerIsXR)
            StartCoroutine(DelayUp(stayTime));
    }

    IEnumerator DelayUp(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool(clickBool, false);
    }

    public void ButtonPressed()
    {
        audio.clip = pressSound;
        audio.Play();
        targetActivate.Activate(); 
    }

    public void ButtonReleased()
    {
        audio.clip = releaseSound;
        audio.Play();
    }
}
