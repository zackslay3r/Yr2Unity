using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFloorCheck : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "platform")
        {
            this.transform.parent = collision.transform;
        }
    }

}
