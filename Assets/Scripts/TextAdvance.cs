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

    int index = 0;
    bool triggeredEvent = false;
    static string Device { get { return (XRDevice.isPresent) ? XRDevice.model : "PC monitor"; } }

    public void Start()
    {
        
    }

    public override void Activate()
    {
        if(index < texts.Length -1)
        {
            index++;
            var text = texts[index].Replace("{%XRDEVICE%}", Device);
            textMesh.text = text;
        }
        if(!triggeredEvent && index == texts.Length -1)
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
