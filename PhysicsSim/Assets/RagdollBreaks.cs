using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBreaks : MonoBehaviour {

    public int BreakStrength;


	// Use this for initialization
	void Start () {
        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();

        foreach (CharacterJoint j in joints)
        {
            j.breakForce = BreakStrength;

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
