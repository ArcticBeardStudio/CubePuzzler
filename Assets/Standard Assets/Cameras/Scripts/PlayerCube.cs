using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {

    // Use this for initialization
     public Material PlayerMaterial;

    
	void Start () {
        //PlayerMaterial = 
        GetComponent<MeshRenderer>().material = PlayerMaterial;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {


        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {


        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {


        }
    }


}
