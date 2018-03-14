using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBreaks : MonoBehaviour {

    public int BreakStrength;
    private int BreakStrengthSquared;
    public int timer;
    private List<GameObject> limbs;

	// Use this for initialization
	void Start () {
       
        limbs = new List<GameObject>();

        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();

  
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();

        foreach (CharacterJoint j in joints)
        {
            BreakStrengthSquared = BreakStrength * BreakStrength;

            if (j.name.Contains("Arm") || j.name.Contains("UpLeg") || j.name.Contains("Head"))
            {
                if (j.currentForce.sqrMagnitude > BreakStrengthSquared)
                {
                    
                    
                    j.gameObject.transform.SetParent(null);
                    limbs.Add(j.gameObject);
                    Destroy(j);
                    foreach (GameObject limb in limbs)
                    {   
                        Destroy(gameObject.transform.root.gameObject, timer);
                        //limbs.Remove(limb);
                        Destroy(limb,timer);
                    }
                }
            }
        }
	}
  
}
