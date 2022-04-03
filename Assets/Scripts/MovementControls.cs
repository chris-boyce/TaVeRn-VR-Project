using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementControls : MonoBehaviour
{
    VivecontrolUwu ViveController;
    private Vector2 movementInput;
    private Rigidbody rb;
    public GameObject Offset;
    private float offsetDistance;


    void Start()
    {
        ViveController = new VivecontrolUwu();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(movementInput.x *2 ,0,0), ForceMode.Impulse);
        rb.AddForce(new Vector3(0, 0, movementInput.y*2), ForceMode.Impulse);

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
                Offset.transform.position = new Vector3(Offset.transform.position.x, -offsetDistance + 1.25f , Offset.transform.position.z) ;


            }
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}
