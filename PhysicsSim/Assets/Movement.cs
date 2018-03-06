using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    CharacterController charControl;
    public float walkSpeed;
    public float jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = 15.0f;
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //MovePlayer(); 
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

    //void FixedUpdate()
    //{
    //    MovePlayer();
    //}

    //void MovePlayer()
    //{
    //    //float horiz = Input.GetAxis("Horizontal");
    //    //float vert = Input.GetAxis("Vertical");

    //    //Vector3 moveDirSide = transform.right * horiz * walkSpeed;
    //    //Vector3 moveDirForward = transform.forward * vert * walkSpeed;

    //    //charControl.SimpleMove(moveDirSide);
    //    //charControl.SimpleMove(moveDirForward);
    //    //charControl.Move(Physics.gravity * Time.deltaTime);
    //}
//}
