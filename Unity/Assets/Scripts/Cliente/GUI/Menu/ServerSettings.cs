using UnityEngine;
using System.Collections;
using Controlador;
using System;

public class ServerSettings : MonoBehaviour {

    //GUI Variables
    public GUISkin myskin;
    public int windowWidth = 353;
    public int windowHeight = 250;
    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    private bool hideWindow = true;
    private Vector2 serverScroll = Vector2.zero;
    private string sDireccionIP = "";
    private string sRemotePort = "";
    private string sAlias = "";
    //relationships
    private ServerMenu menuServer;
    private Control control;

	// Use this for initialization
	void Awake () {
        menuServer = (ServerMenu)GetComponent("ServerMenu");
		control = Control.getControlador();
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
            GUI.Window(1, mainWindow, getMainWindow, "Adicionar Servidor");
        }
    }


    void getMainWindow(int idWindow)
    {
        GUILayout.BeginVertical("box");
        GUILayout.Label("Alias");
        sAlias = GUILayout.TextField(sAlias);
        GUILayout.Label("Direccion Ip");
        sDireccionIP =  GUILayout.TextField(sDireccionIP);
        GUILayout.Label("Puerto de Conexión");
        sRemotePort = GUILayout.TextField(sRemotePort);
        GUILayout.BeginHorizontal("box");
            if(GUILayout.Button("Añadir"))
            {
			 if(control.adicionarServidor(sDireccionIP,sRemotePort,sAlias))
				{
				hide();
                menuServer.show();
				}
            }
            if (GUILayout.Button("Atras"))
            {
                hide();
                menuServer.show();
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
