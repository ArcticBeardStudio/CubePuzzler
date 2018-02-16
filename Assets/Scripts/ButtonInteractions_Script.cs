using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonInteractions_Script : MonoBehaviour {

    
    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}


    public void Startupnewlevel()
    {
        SceneManager_Script.instance.ChangeLevel("CubePuzzler_01");
        while(true)
        {
            if (SceneManager_Script.instance.Currentlevelinformation() == "Main_menu")
            {

                break;
            }
        }
        
        //GameObject Canvas;
        //Canvas = GameObject.FindWithTag("Canvas");
        //Manager_script.instance.yellowAmountText = Canvas.transform.GetChild(0).GetComponent<Text>();
        //Manager_script.instance.blueAmountText = Canvas.transform.GetChild(1).GetComponent<Text>();
        //Manager_script.instance.greenAmountText = Canvas.transform.GetChild(2).GetComponent<Text>();
        //Manager_script.instance.redAmountText = Canvas.transform.GetChild(3).GetComponent<Text>();
        //Manager_script.instance.blackAmountText = Canvas.transform.GetChild(4).GetComponent<Text>();
        //Manager_script.instance.whiteAmountText = Canvas.transform.GetChild(5).GetComponent<Text>();
        //Manager_script.instance.InitGame();
    }

}
