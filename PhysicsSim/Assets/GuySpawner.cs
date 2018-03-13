﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GuySpawner : MonoBehaviour {

    // Have a reference of the prefab we are going to clone
    public GameObject prefab;

    public float timer = 5.0f;
    private float storedTimerValue;
	// Use this for initialization
	void Start () {

        storedTimerValue = timer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            TimerEnded();
        }
	}

    void TimerEnded()
    {
        Instantiate(prefab,gameObject.transform.position,new Quaternion());
        timer = storedTimerValue;
    }
}
