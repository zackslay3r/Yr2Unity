using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpeed : MonoBehaviour {

    public GameObject platform;

	
	// Update is called once per frame
	void Update () {
        

        ConstantSpinning cs = platform.GetComponentInChildren<ConstantSpinning>();
       

        gameObject.GetComponent<TextMesh>().text = "Speed: " + cs.speed.ToString();


    }
}
