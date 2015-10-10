using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public float BUTTONWIDTH = Screen.width / 5;
    public float BUTTONHEIGHT = Screen.height / 4;
    public float BREAKEWIDTH = Screen.width / 10;
    public float BREAKEHEIGHT = Screen.height / 16;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckResolution();
	}

    void CheckResolution()
    {
        BUTTONWIDTH = Screen.width / 5;
        BUTTONHEIGHT = Screen.height / 4;
        BREAKEWIDTH = Screen.width / 10;
        BREAKEHEIGHT = Screen.height / 16;
    }


    void OnGUI()
    {
        //Alcohol MENU
        if (GUI.Button(new Rect(3 * BREAKEWIDTH + 2 * BUTTONWIDTH, 0.575f*Screen.height, BUTTONWIDTH, BUTTONHEIGHT), "pij"))
        {

        }

        if (GUI.Button(new Rect(BREAKEWIDTH, 0.85f*Screen.height, 3 * BUTTONWIDTH + 2 * BREAKEWIDTH, BUTTONHEIGHT / 2), "back"))
        {
            //Back
        }

    }

}
