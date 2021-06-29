using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform center;
    public MouseLook look;
    public Vector3 truePosition;

    // Update is called once per frame
    void LateUpdate()
    {
        //If there is a wall inbetween our camera and player, move camera to the wall

        RaycastHit hit;//temp
        
        if (Physics.Raycast(center.position, transform.position - center.position, out hit, (transform.position - center.position).magnitude))
        {
            Vector3 forward = -(transform.position - center.position).normalized;
            transform.position = hit.point + forward;
            Debug.DrawRay(center.position, hit.point - center.position);
        }
        else
        {
            Debug.DrawRay(center.position, transform.position - center.position);
            transform.localPosition = truePosition;
        }
    }

}
