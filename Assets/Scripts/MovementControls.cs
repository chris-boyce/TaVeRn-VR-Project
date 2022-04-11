using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovementControls : MonoBehaviour
{
    VivecontrolUwu ViveController;
    
    private Vector2 movementInput;
    private Rigidbody rb;
    public GameObject Offset;
    private float offsetDistance;
    public Transform CurrentForwardDirection;
    public Transform cachedForwardDirection;
    private bool isForword;
    private bool isRight;
    public GameObject RightHandUI;
    public GameObject LeftHandUI;
    public GameObject MenuCanvas;
    private bool isMenuActive;
    

    void Start()
    {
        ViveController = new VivecontrolUwu();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
            if(hit.transform.tag == "Ground")
            {
                offsetDistance = hit.distance;
                Offset.transform.position = new Vector3(Offset.transform.position.x, -offsetDistance + 1.75f , Offset.transform.position.z) ;
            }
        }
        isRight = false;
        isForword = false;

        if(movementInput.x > 0.5f)
        {
            rb.AddRelativeForce(cachedForwardDirection.transform.right * 4, ForceMode.Impulse);
        }
        else if(movementInput.x < -0.5f)
        {
            rb.AddRelativeForce(-cachedForwardDirection.transform.right * 4, ForceMode.Impulse);
        }
        else
        {
            isRight = true;
        }


        if (movementInput.y > 0.5f)
        {
            rb.AddRelativeForce(cachedForwardDirection.transform.forward * 4, ForceMode.Impulse);
        }
        else if (movementInput.y < -0.5f)
        {
            rb.AddRelativeForce(-cachedForwardDirection.transform.forward * 4, ForceMode.Impulse);
        }
        else
        {
            isForword = true;
        }

        if(isForword && isRight)
        {
            cachedForwardDirection = CurrentForwardDirection;
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnMenu()
    {
        isMenuActive = !isMenuActive;
        RightHandUI.SetActive(isMenuActive);
        LeftHandUI.SetActive(isMenuActive);
        MenuCanvas.SetActive(isMenuActive);


    }
}
