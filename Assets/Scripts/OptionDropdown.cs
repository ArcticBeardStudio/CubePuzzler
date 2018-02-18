using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionDropdown : MonoBehaviour {

    public Dropdown dropdownlist;
    public Text selectedname;

    public void Dropdown_IndexChanged(int index)
    {

        Manager_script.Movemment value = (Manager_script.Movemment)index;

        Manager_script.instance.movementoptions = value;
    }


	// Use this for initialization
	void Start () {
        Populatelist();
        

    }
	
    public void Populatelist()
    {
        string[] enumNames = Enum.GetNames(typeof(Manager_script.Movemment));
        List<string> options = new List<string>(enumNames);
        dropdownlist.AddOptions(options);
        
    }
	//// Update is called once per frame
	//void Update () {
		
	//}
}
