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
        transform.parent.Find("options").gameObject.SetActive(false);
        transform.parent.parent.Find("Helppanel").gameObject.SetActive(true);
        gameObject.SetActive(false);
        Manager_script.instance.helpmenu = true;
        

    }
    public void Closehelpmenu()
    {
        GameObject temphelp = GameObject.Find("Panel").gameObject;
        temphelp.transform.Find("Save").gameObject.SetActive(true);
        temphelp.transform.Find("Main_menu").gameObject.SetActive(true);
        temphelp.transform.Find("Help").gameObject.SetActive(true);
        temphelp.transform.Find("options").gameObject.SetActive(true);
        temphelp.transform.parent.Find("Helppanel").gameObject.SetActive(false);
        Manager_script.instance.helpmenu = false;
        //transform.parent.Find("Save").gameObject.SetActive(true);
        //transform.parent.Find("Main_menu").gameObject.SetActive(true);
        //transform.parent.Find("options").gameObject.SetActive(true);
        //transform.parent.parent.Find("Helppanel").gameObject.SetActive(false);
        //gameObject.SetActive(true);
        //Manager_script.instance.helpmenu = false;
    }
    public void Optionmenu()
    {

        GameObject temphelp = GameObject.Find("Panel").gameObject;
        Manager_script.instance.optionsmenu = true;


        temphelp.transform.Find("Save").gameObject.SetActive(false);
        temphelp.transform.Find("Main_menu").gameObject.SetActive(false);
        temphelp.transform.Find("Help").gameObject.SetActive(false);
        temphelp.transform.Find("options").gameObject.SetActive(false);
        temphelp.transform.parent.Find("OptionPanel").gameObject.SetActive(true);
        
    }
    public void Closeoptionmenu()
    {
       
        GameObject temphelp = GameObject.Find("Panel").gameObject;
        Manager_script.instance.optionsmenu = false;


        temphelp.transform.Find("Save").gameObject.SetActive(true);
        temphelp.transform.Find("Main_menu").gameObject.SetActive(true);
        temphelp.transform.Find("Help").gameObject.SetActive(true);
        temphelp.transform.Find("options").gameObject.SetActive(true);
        temphelp.transform.parent.Find("OptionPanel").gameObject.SetActive(false);
    }
    public void Openmenu()
    {
        if (Manager_script.instance.optionsmenu || Manager_script.instance.helpmenu) { return; }

        Manager_script.instance.paused = !Manager_script.instance.paused;
        GameObject temp = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Panel").gameObject;
        temp.transform.parent.Find("Menu").gameObject.GetComponent<Button>().gameObject.SetActive(false);
        temp.transform.parent.Find("Reset").gameObject.GetComponent<Button>().gameObject.SetActive(false);
        temp.transform.parent.transform.GetComponent<Canvas_Script>().ShowDirectionButtons(false);
        temp.SetActive(!temp.activeSelf);
    }
    public void Closemenu()
    {
        GameObject temphelp = GameObject.Find("Canvas").gameObject;
        temphelp.transform.Find("Menu").gameObject.GetComponent<Button>().gameObject.SetActive(true);
        temphelp.transform.Find("Reset").gameObject.GetComponent<Button>().gameObject.SetActive(true);
        temphelp.GetComponent<Canvas_Script>().ShowDirectionButtons(true);
        temphelp.transform.Find("Panel").gameObject.SetActive(false);
        Manager_script.instance.paused = !Manager_script.instance.paused;


    }


}
