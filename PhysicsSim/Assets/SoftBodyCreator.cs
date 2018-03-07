using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBodyCreator : MonoBehaviour
{
    public int Length, Width, Height;
    public float springCoefficient, dampering;
    public GameObject softbody;
    public GameObject spawnPoint;
    public float offset;
    // Use this for initialization
    void Start()
    {
        MakeSoftBody(Length, Width, Height, springCoefficient, dampering);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MakeSoftBody(int length, int width, int height, float springCoefficient, float dampening)
    {


        GameObject[,,] arrayOfCircles = new GameObject[length, width, height];

        //List<Vector3Int> iter = new List<Vector3Int> { new Vector3Int(1,0,0), new Vector3Int(-1,0,0),new  }



        // Creation of the spheres.
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                for (int k = 0; k < height; k++)
                {

                    GameObject g = Instantiate(softbody);
                    g.transform.position = spawnPoint.transform.position;
                    arrayOfCircles[i, j, k] = g;
                    //g.transform.position = new Vector3(i + 1 + offset, j + 1 + offset, k + 1 + offset);
                    g.transform.position = new Vector3(spawnPoint.transform.position.x + i * offset, spawnPoint.transform.position.y + j * offset, spawnPoint.transform.position.z + k * offset);
                    g.gameObject.tag = "Softbody";
                }

                //startPos.y += offset;
            }
            //startPos.z += offset;
        }


        bool stopPls = true;
        // Creation of springs.
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                for (int k = 0; k < height; k++)
                {
                    Collider[] results = Physics.OverlapSphere(arrayOfCircles[i, j, k].gameObject.transform.position, offset * 1.414213f);

                    foreach (Collider c in results)
                    {
                        if (stopPls == false)
                        {
                            stopPls = true;
                            continue;
                        }
                        if (c.gameObject.tag == "Softbody")
                        {

                            SpringJoint[] springJoints = c.GetComponents<SpringJoint>();
                            //SpringJoint sj = c.gameObject.AddComponent<SpringJoint>() as SpringJoint;
                            if (j == width)
                            {
                                continue;
                            }

                            //SpringJoint sj = arrayOfCircles[i, j, k].gameObject.AddComponent<SpringJoint>() as SpringJoint;
                            //Rigidbody rb = c.GetComponent<Rigidbody>();
                            // collision objects
                            SpringJoint sj = c.gameObject.AddComponent<SpringJoint>() as SpringJoint;
                            Rigidbody rb = c.GetComponent<Rigidbody>();
                            Rigidbody ourRb = arrayOfCircles[i, j, k].GetComponent<Rigidbody>();

                                    if (rb != null && ourRb != null && rb != ourRb)
                                    {
                                        sj.connectedBody = ourRb;
                                    }

                            foreach (SpringJoint joint in springJoints)
                            {
                                if (joint.connectedBody == arrayOfCircles[i, j, k].gameObject)
                                {
                                    continue;
                                }
                                else
                                {
                                   

                                }

                            }
                        }

                    }

                }
            }

        }

    }
}