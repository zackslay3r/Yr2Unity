using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpinning : MonoBehaviour {

    public float speed;
    


	
	// Update is called once per frame
	void Update ()
    {
        // transform is whatever object this is attached too.
        transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
