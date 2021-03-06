﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Script : MonoBehaviour {

    // THE PATH WE WANT
    List<int> FinalPath = new List<int>();
    List<int> neededNodes = new List<int>();
    List<int> neededNodesIndex = new List<int>();

    public List<GameObject> NodeList = new List<GameObject>();

    

    // Use this for initialization
    void Start () {
        //Debug.Log("NEW GAME");
        /*
        List<int> testRandom = new List<int>();
        testRandom.Add(1);
        //testRandom.Add(4);
        testRandom.Add(8);
        testRandom.Add(9);
        testRandom.Add(13);
        //Debug.Log("random size: " + testRandom.Count);
        NewPath(testRandom);
        
        foreach (int node in FinalPath)
        {
            NodeList[node].transform.Translate(Vector3.up);
            NodeList[node].GetComponent<Node_Script>().Activated = true;
            Debug.Log(node + "\n");
        }*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public List<int> NewPath(List<int> randomIndex)
    {
        //Debug.Log("NEWPATH");
        int currentStart = 0;
        int currentEnd = 1;

        while(currentEnd < randomIndex.Count)
        {
            List<int> proposedPath = new List<int>();
            //Debug.Log("random size: " + randomIndex.Count);
            //Debug.Log("start size: " + currentStart);
            //Debug.Log("end size: " + currentEnd);
            proposedPath = Astar(randomIndex[currentStart], randomIndex[currentEnd]);
            proposedPath.Reverse();
            mergePath(proposedPath);

            currentStart = currentStart + 1;
            currentEnd = currentEnd + 1;
        }
        /*
        while(neededNodes.Count > 0)
        {

            Manager_script.instance.Board[neededNodesIndex[0]].GetComponent<Node_Script>().ColorType = Manager_script.instance.Board[FinalPath[neededNodesIndex[1]]].GetComponent<Node_Script>().ColorType;
            neededNodes.RemoveAt(0);
            neededNodesIndex.RemoveAt(0);
            neededNodesIndex.RemoveAt(0);
        }
        */
        return FinalPath;
    }

    void mergePath(List<int> newSetOfPath)
    {
        
        newSetOfPath.RemoveAt(0);
        //Debug.Log("MergePATH");
        foreach (int node in newSetOfPath)
        {
            //FinalPath.Add(node);
            if (FinalPath.Contains(node))
            {
                int oldColorType = Manager_script.instance.Board[node].GetComponent<Node_Script>().ColorType;
                neededNodes.Add(oldColorType);
                neededNodesIndex.Add(node);
                neededNodesIndex.Add(FinalPath.Count);
                FinalPath.Remove(node);
            }
            else
            {
                if(neededNodes.Count > 0)
                {
                    int oldColorType = Manager_script.instance.Board[node].GetComponent<Node_Script>().ColorType;
                    Manager_script.instance.Board[node].GetComponent<Node_Script>().ColorType = neededNodes[0];
                    neededNodes.RemoveAt(0);
                    neededNodesIndex.RemoveAt(0);
                    neededNodesIndex.RemoveAt(0);
                    oldColorType = Manager_script.instance.Board[node].GetComponent<Node_Script>().ColorType;
                }
                FinalPath.Add(node);
            }
        }
    }

    List<int> Astar (int start, int end)
    {
        //Debug.Log("Astar");
        //List<BadGuy> badguys = new List<BadGuy>();
        List<int> closedSet = new List<int>();
        List<int> openSet = new List<int>();
        openSet.Add(start);
        List<int> cameFrom = new List<int>();

        List<int> fScore = new List<int>();
        List<int> gScore = new List<int>();

        //LOOP OVER THE MAP AND ADD int.MaxValue to each position in fScore and gScore

        for (int i = 0; i < (Manager_script.instance.boardLength * Manager_script.instance.boardWidth); i++)
        {
            fScore.Add(int.MaxValue/2);
            gScore.Add(int.MaxValue/2);
            cameFrom.Add(-1);
            //Debug.Log("Creating enemy number: " + i);
        }

        fScore[start] = heuristic_cost_estimate(start, end);
        gScore[start] = 0;

        while (openSet.Count != 0)
        {
            int nextNode = 0;
            int lowestFScore = int.MaxValue;
            foreach (int node in openSet)
            {
                if(fScore[node] < lowestFScore)
                {
                    nextNode = node;
                    lowestFScore = fScore[node];
                }
            }
            int current = nextNode;

            if (current == end)
            {
                return recreatePath(cameFrom, current, start);
            }
            openSet.Remove(current);
            closedSet.Add(current);

            List<int> neighBours = new List<int>();
            if((current + 1) < (Manager_script.instance.boardLength * Manager_script.instance.boardWidth) && (((current+1)% Manager_script.instance.boardLength) != 0)) //UP
            {
                neighBours.Add(current + 1);
            }
            if ((current + Manager_script.instance.boardLength) < (Manager_script.instance.boardLength * Manager_script.instance.boardWidth)) //RIGHT
            {
                neighBours.Add(current + Manager_script.instance.boardLength);
            }
            if ((current - Manager_script.instance.boardLength) > -1) //LEFT
            {
                neighBours.Add(current - Manager_script.instance.boardLength);
            }
            if (((current - 1) > -1) && (((current) % Manager_script.instance.boardLength) != 0)) //DOWN
            {
                neighBours.Add(current - 1);
            }

            foreach (int node in neighBours)
            {
                if (closedSet.Contains(node))
                {
                    continue;
                }
                if (openSet.Contains(node) == false)
                {
                    openSet.Add(node);
                }

                int testScore = gScore[current] + 10;
                if(testScore >= gScore[node])
                {
                    continue;
                }
                cameFrom[node] = current;
                gScore[node] = testScore;
                fScore[node] = gScore[node] + heuristic_cost_estimate(node, end);
            }
        }
        return openSet;
    }

    List<int> recreatePath (List<int> cameFrom, int current, int start)
    {
        //Debug.Log("RecreatePATH");
        List<int> astar_Path = new List<int>();
        astar_Path.Add(current);
        while (current != start)
        {
            current = cameFrom[current];
            astar_Path.Add(current);
        }
        return astar_Path;
    }

    int heuristic_cost_estimate(int start, int end)
    {
        int hCost = 0;
        
        int yValue = 0;
        int xValue = 0;
        int yCounter = start;
        //CALCULATE BASED on the height and width of the map
        while (yCounter < end)
        {
            yValue = yValue + 1;
            yCounter = yCounter + Manager_script.instance.boardLength;//widthOfBoard
        }
        while (yCounter != end)
        {
            yCounter = yCounter - 1;
            xValue = xValue + 1;
        }
        if(xValue == Manager_script.instance.boardLength)//widthOfBoard
        {
            xValue = 0;
        }
        hCost = xValue * 10 + yValue * 10;
        
        return hCost;
    }
}
