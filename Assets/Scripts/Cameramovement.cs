using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cameramovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MoveCamera(10);

    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = Manager_script.instance.hell + (transform.forward * -1) * 10;
    }
    void MoveCamera(float distance)
    {
        
        transform.position = Manager_script.instance.hell + (transform.forward * -1) * distance;
    }
}
