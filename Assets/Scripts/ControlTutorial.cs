using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class ControlTutorial : MonoBehaviour
{
    [SerializeField]
    protected CanvasGroup cg;
    [SerializeField]
    protected string[] inputListen = new string[] { "Horizontal", "Vertical", "Mouse X", "Mouse Y" };
    [SerializeField]
    protected float fadeTime = 1.5f;

    bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        if(XRDevice.isPresent)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (isPressed)
            return;

        foreach(var axis in inputListen)
        {
            if(Input.GetButton(axis))
            {
                isPressed = true;
                StartCoroutine(FadeControls());
            }
        }
    }

    IEnumerator FadeControls()
    {
        for(float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            cg.alpha = 1f - (t / fadeTime);
            yield return null;
        }
        Destroy(this.gameObject);
    }

}
