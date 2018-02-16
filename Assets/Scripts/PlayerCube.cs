﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {

    // Use this for initialization
     public Material PlayerMaterial;
    private int currenttileindex;
    private Vector3 offset = new Vector3(0, 1, 0); 
     


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
            if (currenttileindex - 1 >= 0)
                currenttileindex = currenttileindex - 1;
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currenttileindex - 1 <= maxboardsize)
                currenttileindex = currenttileindex + 1;
        }
        transform.position = Manager_script.instance.Board[currenttileindex].transform.position + offset;

    }
    void Animate()
    {

    }

}
