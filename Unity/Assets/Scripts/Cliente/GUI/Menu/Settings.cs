using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

    //GUI Variables
    public int windowWidth = 388;
    public int windowHeight = 143;
    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    public GUISkin myskin;
    private bool hideWindow = true;
    
    
    //Music Volume Control
    private float musicVolume = 50.0f;
    private float musicLowerValue = 0.0f;
    private float musicHighestValue = 100.0f;

    //scroll variable
    private Vector2 musicLoudness = Vector2.zero;


	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (!hideWindow)
        {
            GUI.skin = myskin;
            horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
            verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
            mainWindow = new Rect(horizontalCenter, verticalCenter, windowWidth, windowHeight);
            GUI.Window(1, mainWindow, getMainWindow, "Opciones");
        }
    }

    void getMainWindow(int idWindow)
    {
        
        GUILayout.BeginVertical("box");
           
            GUILayout.Label("Loudness : " );

            GUILayout.BeginHorizontal("box");
            musicVolume = GUILayout.HorizontalSlider(musicVolume,musicLowerValue,musicHighestValue,GUILayout.Width(260));
            GUILayout.Label("   " +(int) musicVolume + "%");
            //Music Loudness Changes 
            AudioListener.volume = musicVolume/100;
            GUILayout.EndHorizontal();
        
                if (GUILayout.Button("Menu Principal"))
                {
                    hide();
                    Menu m = (Menu) GetComponent("Menu");
                    m.show();
                }

        GUILayout.EndVertical();

    }


    public void show()
    {
        hideWindow = false;
    }


    public void hide()
    {
        hideWindow = true;
    }
}
