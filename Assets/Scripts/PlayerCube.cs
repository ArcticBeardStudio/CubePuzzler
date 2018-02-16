using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {

    // Use this for initialization
     public Material PlayerMaterial;
    private int currenttileindex;
    private Vector3 offset = new Vector3(0, 1, 0);
    bool playerMoved = false;




    void Start () {
        //PlayerMaterial = 
        GetComponent<MeshRenderer>().material = PlayerMaterial;
        currenttileindex = 2;
    }
	
	// Update is called once per frame
	void Update () {

        int maxboardsize = Manager_script.instance.boardWidth * Manager_script.instance.boardLength;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if ((currenttileindex + 1) < (maxboardsize) && (((currenttileindex + 1) % Manager_script.instance.boardLength) != 0))
            {
                currenttileindex = currenttileindex + 1;
                playerMoved = true;
            }
                

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (((currenttileindex - 1) > -1) && (((currenttileindex) % Manager_script.instance.boardLength) != 0))
            {
                currenttileindex = currenttileindex - 1;
                playerMoved = true;
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ((currenttileindex - Manager_script.instance.boardLength) > -1)
            {
                currenttileindex = currenttileindex - Manager_script.instance.boardLength;
                playerMoved = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((currenttileindex + Manager_script.instance.boardLength) < (maxboardsize))
            {
                currenttileindex = currenttileindex + Manager_script.instance.boardLength;
                playerMoved = true;
            }
        }
        if(playerMoved)
        {
            transform.position = Manager_script.instance.Board[currenttileindex].transform.position + offset;
            if (Manager_script.instance.Board[currenttileindex].GetComponent<Node_Script>().Activated == true)
            {
                Manager_script.instance.Board[currenttileindex].GetComponent<Node_Script>().Activated = false;
            }else
            {
                Manager_script.instance.Board[currenttileindex].GetComponent<Node_Script>().Activated = true;
            }

            Manager_script.instance.PlayerMoved();
            playerMoved = false;
        }
    }
    void Animate()
    {

    }

}
