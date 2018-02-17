using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {

    // Use this for initialization
     public Material PlayerMaterial;
    public int currenttileindex;
    int maxboardsize = Manager_script.instance.boardWidth * Manager_script.instance.boardLength;
    int desiredMove = 0;

    private Vector3 offset = new Vector3(0, 1, 0);
    bool playerMoved = false;





    void Start () {
        //PlayerMaterial = 
        GetComponent<MeshRenderer>().material = PlayerMaterial;
    }
	
	// Update is called once per frame
	void Update () {

        maxboardsize = Manager_script.instance.boardWidth * Manager_script.instance.boardLength;
        desiredMove = 0;
        if (Manager_script.instance.whiteAmountText == null) { return; }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            Moveup();



        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Movedown();

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Moveleft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Moveright();
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
            if (Manager_script.instance.paused == true)
            {
                playerCanMove = false;
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
        if (transform != null )
        {
            if (currenttileindex < Manager_script.instance.Board.Count) { transform.position = Manager_script.instance.Board[currenttileindex].transform.position + offset; }
            
        }
        

    }
    void Animate()
    {

    }
    public void Moveup()
    {
        if ((currenttileindex + 1) < (maxboardsize) && (((currenttileindex + 1) % Manager_script.instance.boardLength) != 0))
        {

            desiredMove = currenttileindex + 1;
            playerMoved = true;
        }
    }
    public void Movedown()
    {
        if (((currenttileindex - 1) > -1) && (((currenttileindex) % Manager_script.instance.boardLength) != 0))
        {
            desiredMove = currenttileindex - 1;
            playerMoved = true;
        }
    }
    public void Moveleft()
    {
        if ((currenttileindex - Manager_script.instance.boardLength) > -1)
        {
            desiredMove = currenttileindex - Manager_script.instance.boardLength;
            playerMoved = true;
        }
    }
    public void Moveright()
    {
        if ((currenttileindex + Manager_script.instance.boardLength) < (maxboardsize))
        {
            desiredMove = currenttileindex + Manager_script.instance.boardLength;
            playerMoved = true;
        }
    }
}
