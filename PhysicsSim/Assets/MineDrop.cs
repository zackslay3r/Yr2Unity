using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDrop : MonoBehaviour {

    WeaponSwitching weaponSwitch;
    public bool beingHeld = true;
    public GameObject realMine;

    // Use this for initialization
    void Start () {
     

    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        {
             GameObject g = Instantiate(realMine,new Vector3(transform.position.x,transform.position.y - 0.1f,transform.position.z),transform.rotation);
            Rigidbody rb = g.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;
        }
	}
}
