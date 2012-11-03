using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
   
    public Texture2D settingsIcon;
    
    //GUI Variables
    public GUISkin myskin;
    public int windowWidth = 388;
    public int windowHeight = 143;
    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    private bool hideWindow = false;

    private string nickname = "";
   


    // Use this for initialization
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public string getNickname() {
        return nickname;
    }

    void OnGUI()
    {
        if (!hideWindow)
        {
            GUI.skin = myskin;
            //Settings
            if (GUI.Button(new Rect(Screen.width - 110, 0, 110, 45), "Configuración"))
            {
                Settings setting = (Settings)GetComponent("Settings");
                hide();
                setting.show();
            }

            horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
            verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
            mainWindow = new Rect(horizontalCenter, verticalCenter, windowWidth, windowHeight);
            GUI.Window(1, mainWindow, getMainWindow, "CLUE - Do you Fear Death?");
        }
    }

    void getMainWindow(int idWindow)
    {
        
        GUILayout.BeginVertical("box");
        GUILayout.Label("Alias : ",GUILayout.Width(388));
        nickname = GUILayout.TextField(nickname);
        GUILayout.BeginHorizontal("box");
            if(GUILayout.Button("Ingresar",GUILayout.Width(150f)))
            {
                ServerMenu serverMenu = (ServerMenu)GetComponent("ServerMenu");
                hide();
                serverMenu.show();
            }
            if (GUILayout.Button("Salir", GUILayout.Width(150f)))
            {
                Application.Quit();
            }
            GUILayout.EndHorizontal();
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
