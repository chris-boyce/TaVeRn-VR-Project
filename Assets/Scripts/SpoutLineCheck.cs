using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoutLineCheck : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public LeverChecker leverCheck;
    private void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (leverCheck.isPour == true)
        {
            lineRenderer.SetPosition(0, transform.position);
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 0.5f))
            {
                lineRenderer.SetPosition(1, hit.point);
                
                if(hit.collider.name == "Mug")
                {
                    Debug.Log("Yes");
                    hit.collider.gameObject.GetComponent<MugController>().FillCup();
                }

            }
            else
            {
                Debug.DrawRay(transform.position, ray.direction, Color.blue);
                lineRenderer.SetPosition(1, transform.position - new Vector3(0, 1f, 0));
            }
        }
        else
        {
            lineRenderer.SetPosition(0, new Vector3(0,0,0));
            lineRenderer.SetPosition(1, new Vector3(0, 0, 0));

        }
            
        

    }
}
