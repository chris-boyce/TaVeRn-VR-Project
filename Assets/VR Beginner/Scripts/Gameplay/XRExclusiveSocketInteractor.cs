using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/// <summary>
/// Subclass of the classic Socket Interactor from the Interaction toolkit that will only accept object with the right
/// SocketTarget 
/// </summary>
public class XRExclusiveSocketInteractor : XRSocketInteractor
{
    public string AcceptedType;
    public GameObject Help;
    public UnityEvent RunCheck;
    public bool Checker = false;
    public GameObject lastGO;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        if(interactable.gameObject != lastGO)
        {
            Checker = false;
        }
        SocketTarget socketTarget = interactable.GetComponent<SocketTarget>();
        if (Checker == false)
        {
            if (interactable.transform.tag == "Mug")
            {
                if (interactable.GetComponent<MugController>().isFull == true)
                {
                    Help = interactable.gameObject;
                    RunCheck.Invoke();

                }
            }
            if (interactable.transform.tag == "Plate")
            {
                Help = interactable.gameObject;
            }
        }

        if (socketTarget == null)
        {
            return false;

        }

        lastGO = interactable.gameObject;
        return base.CanSelect(interactable) && (socketTarget.SocketType == AcceptedType);
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return CanSelect(interactable);
    }

    public void ClearHelp()
    {
        Checker = true;
        Help = null;
       
    }

}
