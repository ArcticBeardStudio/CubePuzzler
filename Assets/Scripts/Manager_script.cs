


using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections;

    using System.Collections.Generic;       //Allows us to use Lists. 
using UnityStandardAssets.Cameras;

public class Manager_script : MonoBehaviour
{

    public static Manager_script instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private Map_script boardScript;                       //Store a reference to our BoardManager which will set up the level.
    public Vector3 hell;
    public Cameramovement Camera;
    private float cameralength = 10f;
    private int level = 1;                                  //Current level number, expressed in game as "Day 1".
    

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
        if (  Input.GetKeyDown(KeyCode.R))
        {
            level++;
            boardScript.RemoveChildren();
            int first = level+1;//Random.Range(level, level+3);
            int second = Random.Range(first, first +1);
            hell = new Vector3((float)first, 0, (float)second);
            hell = hell / 2;
            Debug.Log("first " + first + "second " + second);
            transform.GetChild(0).position = transform.position;
            transform.GetChild(0).position = transform.GetChild(0).position + hell;
            boardScript.SetBoardSize(first, second);

            boardScript.SetupScene(level);
            Camera.transform.position = transform.GetChild(0).position - Camera.transform.forward * cameralength;
        
            cameralength = cameralength + cameralength*0.05f;

        }
    }
}