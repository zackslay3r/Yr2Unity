using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    CharacterController charControl;
    public float walkSpeed;
    public float jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 5.0f;
    float oldY;
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        
        //MovePlayer(); 
        CharacterController controller = GetComponent<CharacterController>();
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y = oldY;
            moveDirection *= walkSpeed;
        if (controller.isGrounded)
        {

            if (Input.GetButton("Jump"))
            {
                oldY = jumpSpeed * Time.deltaTime;
                transform.parent = null;
            }
        }
        else
        {
            oldY -= gravity * Time.deltaTime;
        }
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
