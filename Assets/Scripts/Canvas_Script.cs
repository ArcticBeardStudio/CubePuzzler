using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Manager_script.instance.yellowAmountText = transform.Find("YellowText").GetComponent<Text>();
        Manager_script.instance.blueAmountText = transform.Find("BlueText").GetComponent<Text>();
        Manager_script.instance.greenAmountText = transform.Find("GreenText").GetComponent<Text>();
        Manager_script.instance.redAmountText = transform.Find("RedText").GetComponent<Text>();
        Manager_script.instance.blackAmountText = transform.Find("BlackText").GetComponent<Text>();
        Manager_script.instance.whiteAmountText = transform.Find("WhiteText").GetComponent<Text>();
        Manager_script.instance.InitGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
