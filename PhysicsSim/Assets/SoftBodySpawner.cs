using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBodySpawner : MonoBehaviour {
    //public GameObject softbody;
    public GameObject spawner;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            spawner.GetComponent<SoftBodyCreator>().MakeSoftBody(spawner.GetComponent<SoftBodyCreator>().Length, spawner.GetComponent<SoftBodyCreator>().Width, spawner.GetComponent<SoftBodyCreator>().Height, spawner.GetComponent<SoftBodyCreator>().springCoefficient, spawner.GetComponent<SoftBodyCreator>().dampering);
        }
    }


}
