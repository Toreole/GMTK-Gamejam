using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    protected string buttonTag = "Button";
    [SerializeField]
    protected string interactButton = "Interact";
    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(buttonTag))
        {
            print(other.name);
            if(Input.GetButton(interactButton))
            {
                other.GetComponent<ButtonScript>().Activate(false);
            }
        }
    }
}
