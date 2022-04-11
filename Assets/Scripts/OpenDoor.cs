using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isFlipped;
    public GameObject Door;
    private bool isOpened = false;
    private void Update()
    {
        if (!isFlipped)
        {
            if (Door.transform.rotation.y < 0.05f)
            {
                Door.transform.RotateAround(transform.position, Vector3.down, -70 * Time.deltaTime);
            }
            else if (Door.transform.rotation.y > -0.05f)
            {
                Door.transform.RotateAround(transform.position, Vector3.down, 70 * Time.deltaTime);
            }
        }
        else
        {
            if (Door.transform.rotation.y < -0.05f)
            {
                Door.transform.RotateAround(transform.position, Vector3.down, -70 * Time.deltaTime);
            }
            else if (Door.transform.rotation.y > 0.05f)
            {
                Door.transform.RotateAround(transform.position, Vector3.down, 70 * Time.deltaTime);
            }
        }
    }

}
