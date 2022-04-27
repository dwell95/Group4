using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerGrapple : MonoBehaviour
{
    Vector3 leftHookPosition;
    bool leftHooked;
    [SerializeField] Transform leftLine;
    Vector3 rightHookPosition;
    bool rightHooked;
    [SerializeField] Transform rightLine;
    [SerializeField] Transform camTF;
    [SerializeField] float grappleAcceleration;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(camTF.position, camTF.forward, out hit))
            {
                leftHookPosition = hit.point;
                leftHooked = true;
            }
        }
        if(!Input.GetKey(KeyCode.Mouse0))
        {
            leftHooked = false;
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            if(Physics.Raycast(camTF.position, camTF.forward, out hit))
            {
                rightHookPosition = hit.point;
                rightHooked = true;
            }
        }
        if(!Input.GetKey(KeyCode.Mouse1))
        {
            rightHooked = false;
        }
    }

    void LateUpdate()
    {
        if(leftHooked)
        {
            leftLine.gameObject.SetActive(true);
            leftLine.transform.LookAt(leftHookPosition);
            leftLine.transform.localScale = new Vector3(1,1,Vector3.Distance(transform.position,leftHookPosition));
        }
        else
        {
            leftLine.gameObject.SetActive(false);
        }
        if(rightHooked)
        {
            rightLine.gameObject.SetActive(true);
            rightLine.transform.LookAt(rightHookPosition);
            rightLine.transform.localScale = new Vector3(1,1,Vector3.Distance(transform.position,rightHookPosition));
        }
        else
        {
            rightLine.gameObject.SetActive(false);
        }
    }
    void GrapplePhysics(Vector3 point)
    {
        Vector3 grappleDirection = Vector3.Normalize(point-transform.position);
        GetComponent<Rigidbody>().AddForce(grappleDirection*grappleAcceleration,ForceMode.Acceleration);
    }

    void FixedUpdate()
    {
        if(leftHooked)
        {
            GrapplePhysics(leftHookPosition);
        }
        if(rightHooked)
        {
            GrapplePhysics(rightHookPosition);
        }
    }
}

