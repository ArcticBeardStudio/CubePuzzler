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

    public Path_Script pathScript;
    public static Manager_script instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private Map_script boardScript;                       //Store a reference to our BoardManager which will set up the level.
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
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        
        Debug.Log("init");
      
        int first = level+1;//Random.Range(level, level+3);
        int second = Random.Range(first, first + 1);
        hell = new Vector3((float)first, 0, (float)second);
        hell = hell / 2;
        Debug.Log("first " + first + "second " + second);
        transform.GetChild(0).position = transform.GetChild(0).position+ hell;
        
        boardScript.SetBoardSize(first, second);

        boardScript.SetupScene(level);
        
        pathScript.NodeList = Board;
        GenerateRandomGoals();
        pathScript.lengthOfBoard = boardLength;
        pathScript.widthOfBoard = boardWidth;
        wantedPath = pathScript.NewPath(randomGoals);
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
        
        yellowAmountText.text = yellowAmountLeft.ToString();
        blueAmountText.text = blueAmountLeft.ToString();
        greenAmountText.text = greenAmountLeft.ToString();
        redAmountText.text = redAmountLeft.ToString();
        blackAmountText.text = blackAmountLeft.ToString();
        whiteAmountText.text = whiteAmountLeft.ToString();

        if (Input.GetKey(KeyCode.R))
        {
            boardScript.RemoveChildren();
            int first = Random.Range(level, level+3);
            int second = Random.Range(level, level+3);
            hell = new Vector3((float)first, 0, (float)second);
            hell = hell / 2;
            //Debug.Log("first " + first + "second " + second);
            transform.GetChild(0).position = transform.position;
            transform.GetChild(0).position = transform.GetChild(0).position + hell;
            boardScript.SetBoardSize(first, second);

            boardScript.SetupScene(level);
            level++;
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
            else if (colorType == 1)
            {
                redAmountLeft++;
            }
            else if (colorType == 1)
            {
                yellowAmountLeft++;
            }
            else if (colorType == 1)
            {
                blackAmountLeft++;
            }
            else if (colorType == 1)
            {
                whiteAmountLeft++;
            }
        }
    }
}