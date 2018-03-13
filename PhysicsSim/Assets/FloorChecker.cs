using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour {

    public float fallSpeed;
    public float rayDistance;
    public LayerMask ground;
    private bool isGrounded = false;
    // Update is called once per frame
    void Update () {

        if (isGrounded == false)
        {
            switch (Grounded())
            {
                case true:
                    isGrounded = true;
                    break;

                case false:
                    Vector3 position = transform.position;
                    position.y -= fallSpeed * Time.deltaTime;
                    transform.position = position;
                    break;
            }
        }
        //if (!Grounded())
        //{
        //    Vector3 position = transform.position;
        //    position.y -= fallSpeed * Time.deltaTime;
        //    transform.position = position;
        //}


	}

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, rayDistance, ground);
    }
}
