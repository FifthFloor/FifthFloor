using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {

    //GUI Variables
    private float windowWidth = 0;
    private float windowHeight = 0;
    public float windowHeightMax = 500;
    public float windowWidhtMax = 500;

    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    public GUISkin myskin;
    private bool hideWindow = true;
    public float popUpSpeed = 8f;
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hideWindow)
        {
            OpenPopUp();
        }else{
			closePopUp();
		}
		
    }

    void OnGUI()
    {
        if (!hideWindow)
        {
            GUI.skin = myskin;
            horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
            verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
            mainWindow = new Rect(horizontalCenter, verticalCenter, windowWidth, windowHeight);
            GUI.Window(1, mainWindow, getMainWindow, " Historial ");
        }
    }

    void getMainWindow( int idWindow )
    {

        GUILayout.BeginVertical("box");
      
        GUILayout.TextArea("");

            GUILayout.BeginHorizontal("box");

            if (GUILayout.Button("Cerrar", "button"))
            {
                closePopUp();
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

    private void OpenPopUp()
    {
        if (windowHeight <= windowHeightMax)
        {
            windowHeight = (windowHeight + popUpSpeed);
        }
        if (windowWidth <= windowWidhtMax)
        {
            windowWidth = (windowWidth + popUpSpeed);
        }
    }

    private void closePopUp()
    {
         if (windowHeight >= 0)
        {
            windowHeight = (windowHeight - popUpSpeed);
        }
        if (windowWidth >= 0)
        {
            windowWidth = (windowWidth - popUpSpeed);
        }
    }



}
