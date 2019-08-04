using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class TextAdvance : Activatable
{
    [SerializeField]
    protected string[] texts;
    [SerializeField]
    protected TextMeshPro textMesh;
    [SerializeField]
    protected UnityEngine.Events.UnityEvent onTextComplete;
    [SerializeField]
    protected bool canSkipIfReplay = false;
    [SerializeField]
    protected string skipText = "Ah it's you again.";

    int index = 0;
    bool triggeredEvent = false;
    static string Device { get { return (XRDevice.isPresent) ? XRDevice.model : "PC monitor"; } }
    
    public override void Activate()
    {
        if(index < texts.Length -1)
        {
            if (canSkipIfReplay && ReplayCheck.HasPlayedBefore(false))
            {
                textMesh.text = skipText;
                index = texts.Length - 1;
            }
            else
            {
                index++;
                var text = texts[index].Replace("{%XRDEVICE%}", Device);
                textMesh.text = text;

                if (!triggeredEvent && index == texts.Length - 1)
                {
                    onTextComplete?.Invoke();
                    triggeredEvent = true;
                }
            }
        }
        else if (!triggeredEvent && index == texts.Length - 1)
        {
            onTextComplete?.Invoke();
            triggeredEvent = true;
        }
    }

    public void DebugLog()
    {
        print("reeee");
    }
}
