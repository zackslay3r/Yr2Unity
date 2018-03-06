using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float range = 100;
    public float impactForce = 30;
    public Transform EndOfGun;
    public Camera fpsCam;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // A variable that will store the imformation gathered from the raycast.
        RaycastHit hit;
        Debug.DrawRay(EndOfGun.transform.position, fpsCam.transform.forward * 100, Color.blue, 3.0f);
        // If we hit something with our shot raycast.
        //if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        if (Physics.Raycast(EndOfGun.transform.position, fpsCam.transform.forward, out hit, range)) ;
        {
            // Put in place the takeDamage event handler for the game manager here.
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerManager>().HandleEvent(GameEvent.)
            Debug.DrawLine(fpsCam.transform.position, hit.point, Color.black, 3.0f);

            Debug.Log(hit.transform.name);
            //Target target = hit.transform.GetComponent<Target>();

           
            if (hit.transform.root.GetComponent<Ragdoll>() != null)
            {
                hit.transform.root.GetComponent<Ragdoll>().RagdollOn = true;

            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}