﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PlayerCube : MonoBehaviour {

    // Use this for initialization
     public Material PlayerMaterial;

    public int currenttileindex;
    int maxboardsize = 0;// Manager_script.instance.boardWidth * Manager_script.instance.boardLength;

    int desiredMove = 0;
    bool moveleft = false;
    bool moveright = false;
    bool moveup = false;
    bool movedown = false;

    private Vector3 offset = new Vector3(0, 1, 0);
    bool playerMoved = false;





    void Start () {
        //PlayerMaterial = 
        maxboardsize =  Manager_script.instance.boardWidth* Manager_script.instance.boardLength;
        GetComponent<MeshRenderer>().material = PlayerMaterial;

    }
	
	// Update is called once per frame
	void Update () {

        maxboardsize = Manager_script.instance.boardWidth * Manager_script.instance.boardLength;
        desiredMove = 0;

     

        if (Manager_script.instance.orangeAmountText == null) { return; }


        switch( Manager_script.instance.movementoptions)
        {
            case Manager_script.Movemment.allmovement:
                AllMovement();
                break;
            case Manager_script.Movemment.buttons:
                Mobilebuttonmovement();
                break;
            case Manager_script.Movemment.keyboard:
                Keyboardmovement();
                break;
            case Manager_script.Movemment.touch:
                Mobiletouchmovement();
                break;
            case Manager_script.Movemment.touchandbuttons:
                Touchandbuttonmovement();
                break;

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
            else if (colorType == 4 && (Manager_script.instance.tealAmountLeft - Manager_script.instance.tealAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 5 && (Manager_script.instance.purpleAmountLeft - Manager_script.instance.purpleAmountAct - 1) > -1)
            {
                playerCanMove = true;
            }
            else if (colorType == 6 && (Manager_script.instance.orangeAmountLeft - Manager_script.instance.orangeAmountAct - 1) > -1)
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
    public void Movementdesire(int direction)
    {
        switch(direction)
        {
            case 0:
                movedown = true;
                break;
            case 1:
                moveup = true;
                break;
            case 2:
                moveleft = true;
                break;
            case 3:
                moveright = true;
                break;
        }
    }

    public void Mobiletouchmovement()
    {

        if ( SwipeManager.swipeDirection == Swipe.Up)

        {
           
            Moveup();

            moveup = false;

        }
        else if (SwipeManager.swipeDirection == Swipe.Down)
        {
            Movedown();
            movedown = false;
        }
        else if ( SwipeManager.swipeDirection == Swipe.Left)
        {
            Moveleft();
            moveleft = false;
        }
        else if (SwipeManager.swipeDirection == Swipe.Right)
        {
            Moveright();
            moveright = false;
        }

    }
    public void Mobilebuttonmovement()
    {
        if ( moveup)

        {
            
            Moveup();

            moveup = false;

        }
        else if ( movedown )
        {
            Movedown();
            movedown = false;
        }
        else if ( moveleft)
        {
            Moveleft();
            moveleft = false;
        }
        else if ( moveright )
        {
            Moveright();
            moveright = false;
        }
    }
    public void Keyboardmovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) )

        {
           
            Moveup();

            moveup = false;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) )
        {
            Movedown();
            movedown = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            Moveleft();
            moveleft = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            Moveright();
            moveright = false;
        }
    }
    public void AllMovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || moveup || SwipeManager.swipeDirection == Swipe.Up)

        {
            
            Moveup();

            moveup = false;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || movedown || SwipeManager.swipeDirection == Swipe.Down)
        {
            Movedown();
            movedown = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || moveleft || SwipeManager.swipeDirection == Swipe.Left)
        {
            Moveleft();
            moveleft = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || moveright || SwipeManager.swipeDirection == Swipe.Right)
        {
            Moveright();
            moveright = false;
        }
    }
    public void Touchandbuttonmovement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || moveup || SwipeManager.swipeDirection == Swipe.Up)

        {
            Moveup();

            moveup = false;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || movedown || SwipeManager.swipeDirection == Swipe.Down)
        {
            Movedown();
            movedown = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || moveleft || SwipeManager.swipeDirection == Swipe.Left)
        {
            Moveleft();
            moveleft = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || moveright || SwipeManager.swipeDirection == Swipe.Right)
        {
            Moveright();
            moveright = false;
        }
    }

}
