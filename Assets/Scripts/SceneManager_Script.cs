using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManager_Script : MonoBehaviour {
    public static SceneManager_Script instance = null;
    public string Scene;
    //Awake is always called before any Start functions
    void Awake() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;


        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        SceneManager.LoadScene("Main_menu");
        Scene = "Main_menu";

    }

    // Update is called once per frame
    void Update() {

    }

    public void ChangeLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
        Scene = levelname;

    }
    public string Currentlevelinformation()
    {
         return SceneManager.GetActiveScene().name;
        
    }
    public void Setupcanvas()
    {

    }
        
}
