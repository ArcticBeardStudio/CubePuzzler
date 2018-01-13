using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Node_Script : MonoBehaviour {

    //VARIABLES
    // NodeType - 0 = goalNode, 1 = pathNode, 2 = noPathNode, 3 = startNode, 4 = endNode
    // ColorType - 0 = Green, 1 = Blue, 2 = Red, 3 = Yellow, 4 = Pink, 5 = Orange, 6 = Teal
    int ColorType;
    int NodeType;
    public Material Actualcolor; 
    public Material[] color;


    //if needed for neightbourse 0 is -1 in x column , 1 is +1 in x column, 2 is -1 in y column and 3 is +1 in y column     
    GameObject[] neighbors = new GameObject[4]; 


    // Use this for initialization
    void Start () {
        // Init for Node - set variables

        ColorType = Random.Range(0, color.Length);
        //Actualcolor = GetComponent<MeshRenderer>().materials[0];
        Actualcolor = color[ColorType];
        GetComponent<MeshRenderer>().material = Actualcolor;
        Debug.Log(ColorType);
        //NodeType = Random.Range(0, 4);
        NodeType = 3;

    }
    public void ChangeMaterial(Material newmat)
    {
        GetComponent<MeshRenderer>().material = newmat;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
