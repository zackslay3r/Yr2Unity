using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatforms : MonoBehaviour {



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "platform")
        {
            this.transform.parent = hit.transform;
        }
        else
        {
            this.transform.parent = null;
        }
    }



}
