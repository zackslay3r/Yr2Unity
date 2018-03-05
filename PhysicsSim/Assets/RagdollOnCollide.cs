﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnCollide : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Ragdoll ragdoll = other.gameObject.GetComponentInParent<Ragdoll>();
        if (ragdoll != null)
        {
            ragdoll.RagdollOn = true;
        }
    }
}
