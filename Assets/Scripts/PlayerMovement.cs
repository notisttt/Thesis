using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{[SerializeField] CharacterController CC;
    public Transform cam;
    public float Speed;
    private float Gravity = -9.6f;
    Vector3 Velocity;
    public float turnTime = 0.01f; 
    private float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        if(!CC.isGrounded) {
        
        Velocity.y += Gravity * Time.deltaTime;
        CC.Move(Velocity * Time.deltaTime);
           
        }
           float horiz = Input.GetAxisRaw("Horizontal");
           float vert = Input.GetAxisRaw("Vertical");

           Vector3 Moving = new Vector3(horiz, 0f, vert).normalized;
           
             if (Moving.magnitude >= 0.1f){
        
        float Turning = Mathf.Atan2(Moving.x, Moving.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Turning, ref turnSpeed, turnTime);
        transform.rotation = Quaternion.Euler(0f, Turning, 0f);
         
         Vector3 moveDirec = Quaternion.Euler(0f, Turning, 0f) * Vector3.forward;

        CC.Move(moveDirec.normalized * Speed * Time.deltaTime);

             }

    }
}
