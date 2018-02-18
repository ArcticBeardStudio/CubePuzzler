using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Script : MonoBehaviour {

    List<int> indexBoard = new List<int>();
    List<int> wallIndex = new List<int>();
    List<int> boardLeft = new List<int>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateRooms()
    {

    }

    void cornerRoom()
    {
        List<int> indexCorners = new List<int>();
        indexCorners.Add(0);
        indexCorners.Add(Manager_script.instance.boardLength - 1);
        indexCorners.Add((Manager_script.instance.boardLength * Manager_script.instance.boardWidth) - 1);
        indexCorners.Add((Manager_script.instance.boardLength * Manager_script.instance.boardWidth) - Manager_script.instance.boardLength);

        int selectedCorner = indexCorners[Random.Range(0, indexCorners.Count)];

        //int randRoomWidthMax = Manager_script.instance.boardWidth/Manager_script.instance.numberOfRooms;
        int widthWantedRoom = Random.Range(0, Manager_script.instance.boardWidth);
        int lengthWantedRoom = Random.Range(0, Manager_script.instance.boardLength);

        int widthRoom = 0;
        int lengthRoom = 0;

        bool roomDone = false;
        bool widthCanGrow = true;
        bool lengthCanGrow = true;

        while (!roomDone)
        {
            if(widthCanGrow)
            {
                if(widthRoom < widthWantedRoom)
                {
                    if (selectedCorner == 0 || selectedCorner == Manager_script.instance.boardLength - 1)
                    {
                        if (boardLeft.Contains((widthRoom + 1) * Manager_script.instance.boardLength + selectedCorner))
                        {
                            widthRoom = widthRoom + 1;
                        }
                        else
                        {
                            widthCanGrow = false;
                        }
                    }
                    else
                    {
                        if (boardLeft.Contains((-1 * widthRoom - 1) * Manager_script.instance.boardLength + selectedCorner)) // Handle the negative direction
                        {
                            widthRoom = widthRoom + 1;
                        }
                        else
                        {
                            widthCanGrow = false;
                        }
                    }
                }
                else
                {
                    widthCanGrow = false;
                }
            }
            if(lengthCanGrow)
            {
                if (lengthRoom < lengthWantedRoom)
                {
                    if (selectedCorner == ((Manager_script.instance.boardLength * Manager_script.instance.boardWidth) - 1) || selectedCorner == Manager_script.instance.boardLength - 1)
                    {
                        if (boardLeft.Contains((-1 * lengthRoom - 1) + selectedCorner))
                        {
                            lengthRoom = lengthRoom + 1;
                        }
                        else
                        {
                            lengthCanGrow = false;
                        }
                    }
                    else if(selectedCorner == ((Manager_script.instance.boardLength * Manager_script.instance.boardWidth) - Manager_script.instance.boardLength) || selectedCorner == 0)
                    {
                        if (boardLeft.Contains(( lengthRoom + 1) + selectedCorner))
                        {
                            lengthRoom = lengthRoom + 1;
                        }
                        else
                        {
                            lengthCanGrow = false;
                        }
                    }
                }
                else
                {
                    lengthCanGrow = false;
                }
            }
            //hit kommer vi om rummet är färdigt och inte kan växa något mer
            if(!lengthCanGrow && !widthCanGrow)
            {

            }
        }
    }

    void randomEdgeRoom()
    {

    }
}
