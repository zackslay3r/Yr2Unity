using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour {

    public float timer = 30.0f;
    private float storedTimerValue;

    // Use this for initialization
    void Start () {
		
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
        Destroy(gameObject);
        timer = storedTimerValue;
    }
}
