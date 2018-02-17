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
        Manager_script.instance.paused = false;
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
    public void Mainmenu()
    {
        Manager_script.instance.boardScript.RemoveChildren();
        SceneManager_Script.instance.ChangeLevel("Main_menu");
    }
    public void Starthelpmenu()
    {
        transform.parent.Find("Save").gameObject.SetActive(false);
        transform.parent.Find("Main_menu").gameObject.SetActive(false);
        transform.parent.parent.Find("Helppanel").gameObject.SetActive(true);
        gameObject.SetActive(false);
        Manager_script.instance.helpmenu = true;
        

    }
    public void Closehelpmenu()
    {

    }

}
