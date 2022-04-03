using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Subclass of the classic Socket Interactor from the Interaction toolkit that will only accept object with the right
/// SocketTarget 
/// </summary>
public class XRExclusiveSocketInteractor : XRSocketInteractor
{
    public string AcceptedType;
    public GameObject Help;

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        SocketTarget socketTarget = interactable.GetComponent<SocketTarget>();

        if(interactable.transform.tag == "Mug")
        {
            if(interactable.GetComponent<MugController>().isFull == true)
            {
                Help = interactable.gameObject;
            }
            else
            {
                Help = null;
            }
        }
        

        if (socketTarget == null)
        {
            Help = null;
            return false;

        }
            

        return base.CanSelect(interactable) && (socketTarget.SocketType == AcceptedType);
    }

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return CanSelect(interactable);
    }


}
