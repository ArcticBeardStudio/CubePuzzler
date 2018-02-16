using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;       //Allows us to use Lists. 
    
    public class Manager_script : MonoBehaviour
{
    public Text yellowAmountText;
    public Text blueAmountText;
    public Text greenAmountText;
    public Text redAmountText;
    public Text blackAmountText;
    public Text whiteAmountText;

    int yellowAmountLeft = 0;
    int blueAmountLeft = 0;
    int greenAmountLeft = 0;
    int redAmountLeft = 0;
    int blackAmountLeft = 0;
    int whiteAmountLeft = 0;

    int yellowAmountAct = 0;
    int blueAmountAct = 0;
    int greenAmountAct = 0;
    int redAmountAct = 0;
    int blackAmountAct = 0;
    int whiteAmountAct = 0;

    public Path_Script pathScript;
    public static Manager_script instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public Map_script boardScript;                       //Store a reference to our BoardManager which will set up the level.
    public Vector3 hell;
    private int level = 1;                                  //Current level number, expressed in game as "Day 1".
    public int boardWidth = 8;
    public int boardLength = 5;

    public List<GameObject> Board = new List<GameObject>();
    List<int> wantedPath = new List<int>();
    List<int> randomGoals = new List<int>();

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            
            //if not, set instance to this
            instance = this;


        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        boardScript = GetComponent<Map_script>();
        //Call the InitGame function to initialize the first level 
        
    }

    //Initializes the game for each level.
    public void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        
        Debug.Log("init");
        /*
        int first = level+1;//Random.Range(level, level+3);
        int second = Random.Range(first, first + 1);
        hell = new Vector3((float)first, 0, (float)second);
        hell = hell / 2;
        Debug.Log("first " + first + "second " + second);
        transform.GetChild(0).position = transform.GetChild(0).position+ hell;
        */
        boardScript.SetBoardSize(boardWidth, boardLength);

        boardScript.SetupScene(level);
        
        pathScript.NodeList = Board;
        GenerateRandomGoals();
        pathScript.lengthOfBoard = boardLength;
        pathScript.widthOfBoard = boardWidth;
        hell = new Vector3(boardWidth, 0, boardLength);
        hell = hell / 2;
        wantedPath = pathScript.NewPath(randomGoals);
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = hell + (GameObject.FindGameObjectWithTag("MainCamera").transform.forward * -1) * (boardWidth);
        SetupGame();
    }

    public static void MyDelay(int seconds)
    {
        DateTime dt = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < dt);
    }
    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }

    //Update is called every frame.
    void Update()
    {
        //if (SceneManager_Script.instance.Scene != "Preload" && SceneManager_Script.instance.Scene != "Main_menu")
            if (yellowAmountText != null)
            
        {
            yellowAmountText.text = (yellowAmountLeft - yellowAmountAct).ToString();
            blueAmountText.text = (blueAmountLeft - blueAmountAct).ToString();
            greenAmountText.text = (greenAmountLeft - greenAmountAct).ToString();
            redAmountText.text = (redAmountLeft - redAmountAct).ToString();
            blackAmountText.text = (blackAmountLeft - blackAmountAct).ToString();
            whiteAmountText.text = (whiteAmountLeft - whiteAmountAct).ToString();

            if (Input.GetKey(KeyCode.R))
            {
                boardScript.RemoveChildren();
                //boardWidth = boardWidth + 1; //Random.Range(level, level + 3);
                //boardLength = boardLength + 1;// Random.Range(level, level + 3);
                //hell = new Vector3(boardWidth, 0, boardLength);
                //hell = hell / 2;
                ////Debug.Log("first " + first + "second " + second);
                ////transform.GetChild(0).position = transform.position;
                ////transform.GetChild(0).position = transform.GetChild(0).position + hell;
                //GameObject.FindGameObjectWithTag("MainCamera").transform.position = hell + (GameObject.FindGameObjectWithTag("MainCamera").transform.forward * -1) * (boardWidth+4);
                //boardScript.SetBoardSize(boardWidth, boardLength);

                //boardScript.SetupScene(level);
                level++;
                InitGame();
            }
        }
        
    }

    void GenerateRandomGoals()
    {
        randomGoals.Add(2);
        randomGoals.Add(14);
        randomGoals.Add(20);
        randomGoals.Add(29);
        randomGoals.Add(37);
    }

    void SetupGame()
    {
        foreach(int node in wantedPath)
        {

            int colorType = Board[node].GetComponent<Node_Script>().ColorType;
            // ColorType - 0 = Blue, 1 = Green, 2 = Red, 3 = Yellow, 4 = Black, 5 = White
            if (colorType == 0)
            {
                blueAmountLeft++;
            }
            else if (colorType == 1)
            {
                greenAmountLeft++;
            }
            else if (colorType == 2)
            {
                redAmountLeft++;
            }
            else if (colorType == 3)
            {
                yellowAmountLeft++;
            }
            else if (colorType == 4)
            {
                blackAmountLeft++;
            }
            else if (colorType == 5)
            {
                whiteAmountLeft++;
            }
        }
    }

    public void PlayerMoved()
    {
        yellowAmountAct = 0;
        blueAmountAct = 0;
        greenAmountAct = 0;
        redAmountAct = 0;
        blackAmountAct = 0;
        whiteAmountAct = 0;
        for (int i = 0; i < (Board.Count); i++)
        {
            if(Board[i].GetComponent<Node_Script>().Activated)
            {
                int colorType = Board[i].GetComponent<Node_Script>().ColorType;
                // ColorType - 0 = Blue, 1 = Green, 2 = Red, 3 = Yellow, 4 = Black, 5 = White
                if (colorType == 0)
                {
                    blueAmountAct++;
                }
                else if (colorType == 1)
                {
                    greenAmountAct++;
                }
                else if (colorType == 2)
                {
                    redAmountAct++;
                }
                else if (colorType == 3)
                {
                    yellowAmountAct++;
                }
                else if (colorType == 4)
                {
                    blackAmountAct++;
                }
                else if (colorType == 5)
                {
                    whiteAmountAct++;
                }
            }
        }
    }
}
