using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {

    // Use this for initialization
     public Material PlayerMaterial;
    private int currenttileindex;

     


    void Start () {
        //PlayerMaterial = 
        GetComponent<MeshRenderer>().material = PlayerMaterial;
        currenttileindex = Manager_script.instance.boardWidth / 2;
    }
	
	// Update is called once per frame
	void Update () {

        int maxboardsize = Manager_script.instance.boardWidth * Manager_script.instance.boardLength;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currenttileindex - Manager_script.instance.boardWidth <= maxboardsize)
                currenttileindex = currenttileindex + Manager_script.instance.boardWidth;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currenttileindex- Manager_script.instance.boardWidth >= 0 )
            currenttileindex = currenttileindex - Manager_script.instance.boardWidth;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currenttileindex - Manager_script.instance.boardLength >= 0)
                currenttileindex = currenttileindex - 1;
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currenttileindex - Manager_script.instance.boardLength <= maxboardsize)
                currenttileindex = currenttileindex + 1;
        }
    }
    void Animate()
    {

    }

}
