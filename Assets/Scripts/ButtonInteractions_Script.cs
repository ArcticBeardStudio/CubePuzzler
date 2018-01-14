using System.Collections;
using System.Collections.Generic;
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
    }

}
