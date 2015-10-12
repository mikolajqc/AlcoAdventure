using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public float BUTTONWIDTH = Screen.width / 5;
    public float BUTTONHEIGHT = Screen.height / 4;
    public float BREAKEWIDTH = Screen.width / 10;
    public float BREAKEHEIGHT = Screen.height / 16;

  //labels style class:
    GUIStyle labelStyles = new GUIStyle();
  //  public GUISkin MenuStyle;


 //   public Color colorStart = Color.red;

    public Texture[] amountTextures = new Texture[2];

    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckResolution();
        string message = Drinker.UpdateStatus();
        if (message != "")
            print(message);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
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
        //Creating label styles;
      //  string name = "Arial";
        labelStyles.fontSize = Screen.height/15;
        //    labelStyles.fixedHeight = Screen.height / 20;
        // labelStyles.font.material.SetColor(123, colorStart);
        //GUI.contentColor = Color.yellow;

        GUI.Label(new Rect(BREAKEWIDTH, BREAKEHEIGHT, 100, 20), "Alcohol level: ", labelStyles);
        GUI.Label(new Rect(BREAKEWIDTH, 2*BREAKEHEIGHT, 100, 20), Drinker.CalculatePromils().ToString() + "‰",labelStyles);
        GUI.Label(new Rect(BREAKEWIDTH, 4 * BREAKEHEIGHT, 100, 20), "Sober by: ",labelStyles);
        GUI.Label(new Rect(BREAKEWIDTH, 5 * BREAKEHEIGHT, 100, 20), Drinker.soberingTime.Hour.ToString() +":"+ Drinker.soberingTime.Minute.ToString(),labelStyles);
        GUI.Label(new Rect(BREAKEWIDTH, 6 * BREAKEHEIGHT, 100, 20), Drinker.soberingTime.Day.ToString() + "." + Drinker.soberingTime.Month.ToString()+ "." + Drinker.soberingTime.Year.ToString(),labelStyles);

        //Alcohol MENU
        if (GUI.Button(new Rect(BREAKEWIDTH, 0.575f*Screen.height, 3 * BUTTONWIDTH + 2 * BREAKEWIDTH, BUTTONHEIGHT), amountTextures[0]))
        {
            print("One more");
            Drinker.Drink(VolumeSelect.alcoholMass);
        }
        if (GUI.Button(new Rect(BREAKEWIDTH, 0.85f*Screen.height, 3 * BUTTONWIDTH + 2 * BREAKEWIDTH, BUTTONHEIGHT / 2), amountTextures[1]))
        {
            print("Back to AlcoholSelect");
            Application.LoadLevel("AlcoholSelect");
        }
    }
}
