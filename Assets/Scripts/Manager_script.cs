using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;       //Allows us to use Lists. 
    
    public class Manager_script : MonoBehaviour
{
    public Text levelText;

    public Text yellowAmountText;
    public Text blueAmountText;
    public Text greenAmountText;
    public Text redAmountText;
    public Text tealAmountText;
    public Text purpleAmountText;
    public Text orangeAmountText;

    public int yellowAmountLeft = 0;
    public int blueAmountLeft = 0;
    public int greenAmountLeft = 0;
    public int redAmountLeft = 0;
    public int tealAmountLeft = 0;
    public int purpleAmountLeft = 0;
    public int orangeAmountLeft = 0;

    public int yellowAmountAct = 0;
    public int blueAmountAct = 0;
    public int greenAmountAct = 0;
    public int redAmountAct = 0;
    public int tealAmountAct = 0;
    public int purpleAmountAct = 0;
    public int orangeAmountAct = 0;

    public GameObject debugCube;

    public Path_Script pathScript;
    public GameObject playerReference;
    public static Manager_script instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public Map_script boardScript;                       //Store a reference to our BoardManager which will set up the level.
    public Vector3 hell;
    public bool paused = false;
    public bool helpmenu = false;
    private int level = 1;                                  //Current level number, expressed in game as "Day 1".
    public int boardWidth;
    public int boardLength;
    public int startBoardWidth = 4;
    public int startBoardLength = 3;
    public int startIndex;
    int endIndex;
    public int CheckpointsAmount;
    public int ColorsAmount;

    bool canChangeLevel = true;

    public List<GameObject> Board = new List<GameObject>();
    public List<GameObject> DebugList = new List<GameObject>();
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
        Random.InitState(level);
        wantedPath.Clear();
        randomGoals.Clear();
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        
        Debug.Log("Init Level: " + level);

        playerReference = GameObject.Find("PlayerCube");
        /*
        int first = level+1;//Random.Range(level, level+3);
        int second = Random.Range(first, first + 1);
        hell = new Vector3((float)first, 0, (float)second);
        hell = hell / 2;
        Debug.Log("first " + first + "second " + second);
        transform.GetChild(0).position = transform.GetChild(0).position+ hell;
        */
        boardWidth = (int)Math.Floor(Math.Log10(level) * 3 * Math.Log10(level) + 4);
        if(boardWidth/2 == boardLength && boardWidth != 4 && boardWidth != 5)
        {
            boardLength = boardLength + 2;
        }

        startIndex = (int)Math.Floor((float)boardLength / 2);
        playerReference.GetComponent<PlayerCube>().currenttileindex = startIndex;
        endIndex = startIndex + (boardLength * (boardWidth - 1));
        CheckpointsAmount = (int)Math.Floor((float)boardWidth / 2);//HARDCODED
        
        ColorsAmount = (int)Math.Floor(Math.Log10(level) * 1.3 * Math.Log10(level) + 3);
        if(ColorsAmount > 7)
        {
            ColorsAmount = 7;
        }

        boardScript.SetBoardSize(boardWidth, boardLength);

        boardScript.SetupScene(level);
        
        pathScript.NodeList = Board;
        GenerateRandomGoals();
        
        hell = new Vector3(boardWidth-1, 0, boardLength);
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
            tealAmountText.text = (tealAmountLeft - tealAmountAct).ToString();
            purpleAmountText.text = (purpleAmountLeft - purpleAmountAct).ToString();
            orangeAmountText.text = (orangeAmountLeft - orangeAmountAct).ToString();

            levelText.text = level.ToString();

            if (Input.GetKeyDown(KeyCode.R))
            {
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
                Resetlevel();
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                boardScript.RemoveChildren();

                level++;
                InitGame();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if(DebugList.Count > 0)
                {
                    for (int i = 0; i < (DebugList.Count); i++)
                    {
                        GameObject.Destroy(DebugList[i]);
                    }
                    DebugList.Clear();
                }
                else
                {
                    for (int i = 0; i < (wantedPath.Count); i++)
                    {
                        GameObject instance = Instantiate(debugCube, new Vector3(0, 0f, 0), Quaternion.identity) as GameObject;
                        instance.transform.position = Board[wantedPath[i]].transform.position + Vector3.up;
                        DebugList.Add(instance);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (paused && helpmenu)
                {
                    GameObject temphelp = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Helppanel").gameObject;
                    temphelp.SetActive(!temphelp.activeSelf);
                    
                    temphelp.transform.parent.Find("Panel").Find("Save").gameObject.SetActive(true);
                    temphelp.transform.parent.Find("Panel").Find("Main_menu").gameObject.SetActive(true);
                    temphelp.transform.parent.Find("Panel").Find("Help").gameObject.SetActive(true);
                    helpmenu = !helpmenu;
                    return;
                }

                GameObject temp = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Panel").gameObject;
                paused = !paused;
                temp.SetActive(!temp.activeSelf);

                
                
            }

        }
        
    }

    void GenerateRandomGoals()
    {
        randomGoals.Add(startIndex);
        List<int> unsortedRandomGoals = new List<int>();
        for (int i = 0; i < (CheckpointsAmount); i++)
        {
            int randIndex = Random.Range(0, ((boardWidth-1) * boardLength) - 1);
            unsortedRandomGoals.Add(randIndex);
        }
        unsortedRandomGoals.Sort();
        for (int i = 0; i < (unsortedRandomGoals.Count); i++)
        {
            randomGoals.Add(unsortedRandomGoals[i]);
        }
        randomGoals.Add(endIndex);
    }

    void SetupGame()
    {
        yellowAmountLeft = 0;
        blueAmountLeft = 0;
        greenAmountLeft = 0;
        redAmountLeft = 0;
        tealAmountLeft = 0;
        purpleAmountLeft = 0;
        orangeAmountLeft = 0;

        yellowAmountAct = 0;
        blueAmountAct = 0;
        greenAmountAct = 0;
        redAmountAct = 0;
        tealAmountAct = 0;
        purpleAmountAct = 0;
        orangeAmountAct = 0;

        foreach (int node in wantedPath)
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
                tealAmountLeft++;
            }
            else if (colorType == 5)
            {
                purpleAmountLeft++;
            }
            else if (colorType == 6)
            {
                orangeAmountLeft++;
            }
        }
    }

    public void PlayerMoved()
    {
        yellowAmountAct = 0;
        blueAmountAct = 0;
        greenAmountAct = 0;
        redAmountAct = 0;
        tealAmountAct = 0;
        purpleAmountAct = 0;
        orangeAmountAct = 0;

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
                    tealAmountAct++;
                }
                else if (colorType == 5)
                {
                    purpleAmountAct++;
                }
                else if (colorType == 6)
                {
                    orangeAmountAct++;
                }
            }
        }
        LevelFinished();
    }

    public void LevelFinished()
    {
        if(yellowAmountLeft - yellowAmountAct == 0 &&
            blueAmountLeft - blueAmountAct == 0 &&
            greenAmountLeft - greenAmountAct == 0 &&
            redAmountLeft - redAmountAct == 0 &&
            tealAmountLeft - tealAmountAct == 0 &&
            purpleAmountLeft - purpleAmountAct == 0 &&
            orangeAmountLeft - orangeAmountAct == 0 &&
            playerReference.GetComponent<PlayerCube>().currenttileindex == endIndex
            )
        {
            boardScript.RemoveChildren();
            level++;
            InitGame();
        }
    }
    public void Resetlevel()
    {
        boardScript.RemoveChildren();
        InitGame();
    }
}
