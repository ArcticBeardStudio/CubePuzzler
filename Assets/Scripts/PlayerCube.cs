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
        int desiredMove = 0;
        if (Manager_script.instance.whiteAmountText == null) { return; }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            if ((currenttileindex + 1) < (maxboardsize) && (((currenttileindex + 1) % Manager_script.instance.boardLength) != 0))
            {

                desiredMove = currenttileindex + 1;
                playerMoved = true;
            }
                

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (((currenttileindex - 1) > -1) && (((currenttileindex) % Manager_script.instance.boardLength) != 0))
            {
                desiredMove = currenttileindex - 1;
                playerMoved = true;
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ((currenttileindex - Manager_script.instance.boardLength) > -1)
            {
                desiredMove = currenttileindex - Manager_script.instance.boardLength;
                playerMoved = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((currenttileindex + Manager_script.instance.boardLength) < (maxboardsize))
            {
                desiredMove = currenttileindex + Manager_script.instance.boardLength;
                playerMoved = true;
            }
        }
        if(playerMoved)
        {
            bool playerCanMove = false;
            int colorType = Manager_script.instance.Board[desiredMove].GetComponent<Node_Script>().ColorType;
            if (colorType == 0 && (Manager_script.instance.blueAmountLeft - Manager_script.instance.blueAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 1 && (Manager_script.instance.greenAmountLeft - Manager_script.instance.greenAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 2 && (Manager_script.instance.redAmountLeft - Manager_script.instance.redAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 3 && (Manager_script.instance.yellowAmountLeft - Manager_script.instance.yellowAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 4 && (Manager_script.instance.blackAmountLeft - Manager_script.instance.blackAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 5 && (Manager_script.instance.whiteAmountLeft - Manager_script.instance.whiteAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            if (Manager_script.instance.Board[desiredMove].GetComponent<Node_Script>().Activated && !playerCanMove)
            {
                playerCanMove = true;
            }
            if (playerCanMove) //Can move
            {
                currenttileindex = desiredMove;
                transform.position = Manager_script.instance.Board[currenttileindex].transform.position + offset;
                if (Manager_script.instance.Board[currenttileindex].GetComponent<Node_Script>().Activated)
                {
                    Manager_script.instance.Board[currenttileindex].GetComponent<Node_Script>().Activated = false;
                }
                else
                {
                    Manager_script.instance.Board[currenttileindex].GetComponent<Node_Script>().Activated = true;
                }

                Manager_script.instance.PlayerMoved();
                
            }
            playerMoved = false;
        }
        transform.position = Manager_script.instance.Board[currenttileindex].transform.position + offset;

    }
    void Animate()
    {

    }

}
