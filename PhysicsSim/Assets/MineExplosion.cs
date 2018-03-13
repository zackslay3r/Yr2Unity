using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {
    public float radius;
    public float force;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 explosionPos = transform.position;

        Rigidbody[] rigidbodies = other.transform.root.GetComponentsInChildren<Rigidbody>();

        if (other.transform.root.GetComponent<Ragdoll>() != null)
        {
            if (!other.transform.root.GetComponent<Ragdoll>().RagdollOn)
            {
                //Ragdoll ragdoll = hit.transform.root.GetComponent<Ragdoll>();
                Rigidbody rb = other.GetComponent<Rigidbody>();
                other.transform.root.GetComponent<Ragdoll>().RagdollOn = true;

                foreach (Rigidbody r in rigidbodies)
                {
                    r.isKinematic = false;
                }
                rb.AddExplosionForce(force, gameObject.transform.position, radius, 10.0f);
                //Debug.Log(hit.transform.root.GetComponent<Ragdoll>().RagdollOn);
                //other.transform.rigidbody.AddForceAtPosition((hit.point - EndOfGun.transform.position).normalized * impactForce, hit.point);

            }


        }
    }
}
