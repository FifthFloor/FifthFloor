using UnityEngine;
using System.Collections;

public class TemplateGUI : MonoBehaviour
{
    //GUI Variables
    public int windowWidth = 388;
    public int windowHeight = 143;
    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    public GUISkin myskin;
    private bool hideWindow = true;

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
            GUI.Window(1, mainWindow, getMainWindow, "Editar Servidores : ");
        }
    }

    void getMainWindow(int idWindow)
    {
        
        GUILayout.BeginVertical("box");
           
         //your code here

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

