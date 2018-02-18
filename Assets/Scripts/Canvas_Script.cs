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
    public void Resetlevel()
    {
        Manager_script.instance.Resetlevel();
    }
    public void Optionchange()
    {
        ShowDirectionButtons(Manager_script.instance.showbuttons);
    }
    public void ShowDirectionButtons(bool state)
    {
        transform.Find("Movedown").gameObject.SetActive(state);
        transform.Find("Moveup").gameObject.SetActive(state);
        transform.Find("Moveleft").gameObject.SetActive(state);
        transform.Find("Moveright").gameObject.SetActive(state);
    }
    public void Openmenu()
    {
        if (Manager_script.instance.optionsmenu || Manager_script.instance.helpmenu) { return; }

        Manager_script.instance.paused = !Manager_script.instance.paused;
        GameObject temp = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Panel").gameObject;

        temp.SetActive(!temp.activeSelf);
    }
}
