using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    protected string buttonTag = "Button";
    [SerializeField]
    protected string interactButton = "Interact";
    [SerializeField]
    protected GameObject pressEText;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(buttonTag))
        {
            //print(other.name);
            if(Input.GetButton(interactButton))
            {
                other.GetComponent<ButtonScript>().Activate(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(buttonTag))
        {
            pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(buttonTag))
        {
            pressEText.SetActive(false);
        }
    }
}
