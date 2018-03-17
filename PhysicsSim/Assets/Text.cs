using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour {

    public GameObject button;
    private SoftBodyCreator SpawnerScript;

    private void Start()
    {
        SpawnerScript = button.GetComponent<SoftBodySpawner>().spawner.GetComponent<SoftBodyCreator>();
    }
    // Update is called once per frame
    void Update () {

        gameObject.GetComponent<TextMesh>().text = "Width: " + SpawnerScript.Width.ToString() + " " + "Height: " + SpawnerScript.Height.ToString() + " "+ "Breadth:" + SpawnerScript.Length.ToString() ;

    }
}
