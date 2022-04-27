using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float moveAcceleration;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float sprintSpeed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    Transform camTF;
    public int frames;
    public int stopFrame;
    
    bool hasLifted;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0,transform.localRotation.eulerAngles.y+Input.GetAxisRaw("Mouse X"),0);
        camTF.localRotation = Quaternion.Euler(camTF.localRotation.eulerAngles.x-Input.GetAxisRaw("Mouse Y"),0,0);
        if(Input.GetButtonDown("Jump"))
        {
            stopFrame = frames;
            frames = -5;
        }
    }

    void FixedUpdate()
    {
        frames+=1;
    }
    void OnCollisionStay(Collision collision)
    {   
        Vector3 moveVector = transform.TransformDirection(Vector3.Normalize(new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"))));
        float moveSpeed = walkSpeed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        Vector3 correction = Vector3.Normalize(moveSpeed*moveVector-rb.velocity);
        float moveMod = 1-Mathf.Max(0,Vector3.Dot(correction,rb.velocity))/sprintSpeed;
        rb.velocity = Vector3.MoveTowards(rb.velocity,moveVector*moveSpeed,moveMod*moveAcceleration*Time.fixedDeltaTime);
        if(frames<=1)
        {
            rb.AddForce(Vector3.Normalize(collision.contacts[0].normal+Vector3.up)*jumpSpeed,ForceMode.VelocityChange);
            frames=2;
            hasLifted = false;
        }    
    }
}
