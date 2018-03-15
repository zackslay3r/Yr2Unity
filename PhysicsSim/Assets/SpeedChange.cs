using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChange : MonoBehaviour {

    public GameObject[] platforms;

    public enum IncreaseDecrease { ADD, SUBTRACT };

    public IncreaseDecrease selector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (selector)
            {
                case IncreaseDecrease.ADD:
                    foreach (GameObject platform in platforms)
                    {
                        ConstantSpinning cs = platform.GetComponentInChildren<ConstantSpinning>();
                        if (cs != null)
                        {
                            cs.speed += 10;
                        }
                    }
                    break;
                case IncreaseDecrease.SUBTRACT:
                    foreach (GameObject platform in platforms)
                    {
                        ConstantSpinning cs = platform.GetComponentInChildren<ConstantSpinning>();
                        if (cs != null)
                        {
                            if (cs.speed > 9)
                            {
                                cs.speed -= 10;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
