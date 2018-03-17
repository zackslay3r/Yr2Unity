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
    private Vector3 startCentre;
    private Vector3 startScale;


    private float startHeight;
    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        startHeight = charControl.height;
        startCentre = charControl.center;
        startScale = gameObject.transform.GetChild(1).localScale;

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

            crouch();

        }
        else
        {
            oldY -= gravity * Time.deltaTime;
        }
            charControl.Move(moveDirection * Time.deltaTime);
    }


    void crouch()
    {

        Vector3 newCentre = startCentre;
        Vector3 newScale = startScale;


        float newHeight = startHeight;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            //isCrouched = true;
            newHeight = 0.5f * startHeight;
            //newCentre.y = 0.2f;
            newScale = new Vector3(newScale.x, 0.5f, newScale.z);


        }

        float lastHeight = charControl.height;
        Vector3 lastCentre = newCentre;
        Vector3 lastScale = newScale;

        gameObject.transform.GetChild(1).localScale = Vector3.Lerp(gameObject.transform.GetChild(1).localScale, lastScale, 5.0f * Time.deltaTime);


        charControl.height = Mathf.Lerp(charControl.height, newHeight, 5.0f * Time.deltaTime);
        charControl.center = new Vector3(newCentre.x, newCentre.y, newCentre.z);


        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + (charControl.height - lastHeight) * 0.5f, gameObject.transform.position.z);

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
