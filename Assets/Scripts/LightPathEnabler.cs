using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPathEnabler : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] lights;
    [SerializeField]
    protected float delayBetween = 0.2f;
    [SerializeField]
    protected GameObject lastEnable;
    [SerializeField]
    protected bool enable = false;
    [SerializeField]
    protected float lastDelay = 0.7f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        var delay = new WaitForSeconds(delayBetween);
        foreach(var go in lights)
        {
            go.SetActive(true);
            yield return delay;
        }
        yield return new WaitForSeconds(lastDelay);
        lastEnable.SetActive(enable);
    }
    
}
