using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBreaks : MonoBehaviour {

    public int BreakStrength;
    private int BreakStrengthSquared;
    public int timer;

	// Use this for initialization
	void Start () {
        //Set BreakStrengthSquared.
        //BreakStrengthSquared = BreakStrength * BreakStrength;



        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();

        foreach (CharacterJoint j in joints)
        {
            //if (j.name.Contains("Arm") || j.name.Contains("UpLeg") || j.name.Contains("Head"))
            //{
            //    j.breakForce = BreakStrength;
            //}
           
        }
	}
	
	// Update is called once per frame
	void Update () {

        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();

        foreach (CharacterJoint j in joints)
        {
            BreakStrengthSquared = BreakStrength * BreakStrength;

            if (j.name.Contains("Arm") || j.name.Contains("UpLeg") || j.name.Contains("Head"))
            {
                if (j.currentForce.sqrMagnitude > BreakStrengthSquared)
                {
                    Destroy(gameObject.transform.root.gameObject, timer);
                    j.gameObject.transform.SetParent(null);
                    Destroy(j);
                    
                }
            }
        }
  // testing pls

 
        foreach (CharacterJoint j in joints)
        {
            if (j.name.Contains("Head"))
            {
               CharacterJoint testJoint = j;
                //Debug.Log(testJoint.currentForce);
        
            }
            
        }
	}
  
}
