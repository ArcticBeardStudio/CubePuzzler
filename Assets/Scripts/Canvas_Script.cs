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
        Manager_script.instance.tealAmountText = transform.Find("TealText").GetComponent<Text>();
        Manager_script.instance.purpleAmountText = transform.Find("PurpleText").GetComponent<Text>();
        Manager_script.instance.orangeAmountText = transform.Find("OrangeText").GetComponent<Text>();
        Manager_script.instance.levelText = transform.Find("LevelText").GetComponent<Text>();
        Manager_script.instance.InitGame();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
