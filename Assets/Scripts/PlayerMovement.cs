using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{[SerializeField] CharacterController CC;
    Animator m_Animator;
    public Transform cam;
    public float Speed;
    private float Gravity = -9.6f;
    Vector3 Velocity;                              //metavlites gia ta physics, to walking/running animation, tin kamera kai tin taxitita tou paikti
    public float turnTime = 0.01f; 
    private float turnSpeed;
   


    void Start(){
        m_Animator = GetComponent<Animator> ();
                                                                   //animator gia to walking/running animation

    }

    void Update()
    {
        if(!CC.isGrounded) {
        
        Velocity.y += Gravity * Time.deltaTime;
        CC.Move(Velocity * Time.deltaTime);
           
        }
           float horiz = Input.GetAxisRaw("Horizontal");
           float vert = Input.GetAxisRaw("Vertical");

           Vector3 Moving = new Vector3(horiz, 0f, vert).normalized;
                                                                                          //kwdikas gia tin kinisi tou paikti kai ta WASD inputs
           bool hasHorizontalInput = !Mathf.Approximately (horiz, 0f);
            bool hasVerticalInput = !Mathf.Approximately (vert, 0f);
            bool isMoving = hasHorizontalInput || hasVerticalInput;
             m_Animator.SetBool ("IsMoving", isMoving);                                   //walking animation

             if (Moving.magnitude >= 0.1f){
        
        float Turning = Mathf.Atan2(Moving.x, Moving.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Turning, ref turnSpeed, turnTime);
        transform.rotation = Quaternion.Euler(0f, Turning, 0f);
         
         Vector3 moveDirec = Quaternion.Euler(0f, Turning, 0f) * Vector3.forward;

        CC.Move(moveDirec.normalized * Speed * Time.deltaTime);

             }

           


             
             



    }
}
