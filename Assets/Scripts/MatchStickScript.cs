using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStickScript : MonoBehaviour
{
    private float speedPerSec;
    private Vector3 oldPosition;
    private float speed;
    private Renderer cubeRenderer;

    private Color colorStart = Color.red;
    private Color colorEnd = new Color(1.0f, 0.64f, 0.0f);
    private Color colorDead = Color.black;

    private bool isLit = false;

    private void Start()
    {
        cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.color = colorStart;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Ignite" && isLit == true)
        {
            other.transform.GetComponent<IgniteObject>().Light();
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "MatchSide" && isLit == false)
        {
            speedPerSec = Vector3.Distance(oldPosition, transform.position) / Time.deltaTime;
            speed = Vector3.Distance(oldPosition, transform.position);
            oldPosition = transform.position;
            if (speedPerSec > 1.5f && speedPerSec < 5)
            {
                isLit = true;
                StartCoroutine(LitTimer());
                cubeRenderer.material.color = colorEnd;

            }
        }
    }
    IEnumerator LitTimer()
    {
        yield return new WaitForSeconds(10f);
        isLit = false;
        cubeRenderer.material.color = colorDead;
    }

}
