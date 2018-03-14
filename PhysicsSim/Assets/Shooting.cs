using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float range = 100;
    public float impactForce;
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
        Debug.DrawRay(EndOfGun.transform.position, fpsCam.transform.forward * range, Color.blue, 3.0f);
        // If we hit something with our shot raycast.
        //if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Put in place the takeDamage event handler for the game manager here.
            //GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerManager>().HandleEvent(GameEvent.)
            Debug.DrawLine(fpsCam.transform.position, hit.point, Color.black, 3.0f);

            Debug.Log(hit.transform.name);
            //Target target = hit.transform.GetComponent<Target>();
            Rigidbody[] rigidbodies = transform.root.GetComponentsInChildren<Rigidbody>();
           
            if (hit.transform.root.GetComponent<Ragdoll>() != null)
            {
                if (!hit.transform.root.GetComponent<Ragdoll>().RagdollOn)
                {
                    //Ragdoll ragdoll = hit.transform.root.GetComponent<Ragdoll>();
                    hit.transform.root.GetComponent<Ragdoll>().RagdollOn = true;

                    foreach (Rigidbody r in rigidbodies)
                    {
                        r.isKinematic = false;
                    }

                    //Debug.Log(hit.transform.root.GetComponent<Ragdoll>().RagdollOn);
                    hit.rigidbody.AddForceAtPosition((hit.point - EndOfGun.transform.position).normalized * impactForce,hit.point);
                }
                
                
            }
            if (hit.transform.tag == "Softbody" )
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}