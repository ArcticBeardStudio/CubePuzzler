using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skip_main_menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SceneManager_Script.instance.ChangeLevel("CubePuzzler_01");
        //while (true)
        //{
        //    if (SceneManager_Script.instance.Currentlevelinformation() == "Main_menu")
        //    {

        //        break;
        //    }
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
