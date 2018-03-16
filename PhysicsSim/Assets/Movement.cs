using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    CharacterController charControl;
    public float speed;
    public float jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 5.0f;
    float oldY;
    public bool isCrouched = false;
    public float walkSpeed, crouchSpeed;

    private float startHeight;
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        startHeight = charControl.height;
    }

    private void Update()
    {
        
        //MovePlayer(); 

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y = oldY;
            moveDirection *= speed;
        if (charControl.isGrounded)
        {

            if (Input.GetButton("Jump"))
            {
                oldY = jumpSpeed * Time.deltaTime;
                transform.parent = null;
            }

            float newHeight = startHeight;
            //crouch();
            if (Input.GetKey(KeyCode.LeftControl))
            {
                //isCrouched = true;
                newHeight = 0.5f * startHeight;
            }
            
            float lastHeight = charControl.height;


            charControl.height = Mathf.Lerp(charControl.height, newHeight, 5.0f * Time.deltaTime);
            //transform.localScale = new Vector3(transform.localScale.x, charControl.height, transform.localScale.z);

            gameObject.transform.position = new Vector3(transform.position.x,transform.position.y + (charControl.height - lastHeight) * 1f, transform.position.z);

            //if (isCrouched)
            //{
            //    charControl.height = 1f; //crouch height

            //    transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            //}
            //else
            //{
            //    charControl.height = 2f; //player height
            //                             //transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            //                             //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            //}

        }
        else
        {
            oldY -= gravity * Time.deltaTime;
        }
            charControl.Move(moveDirection * Time.deltaTime);
    }


    void crouch()
    {
 
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouched = true;
            
        }
        else
        {
            isCrouched = false;
        }

        if (isCrouched)
        {
            charControl.height = 1f; //crouch height

            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        }
        else
        {
            charControl.height = 2f; //player height
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }

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
