using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Controlador; 
using System;

public class ServerEditSettings : MonoBehaviour
{

    //GUI Variables
    public int windowWidth = 388;
    public int windowHeight = 143;
    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    public GUISkin myskin;
    private bool hideWindow = true;
    private int selGridInt = 0;
	private string[] selStrings = new string[] {};
	
	
	//relationships
	private Control control = null;
	private ServerMenu menu = null;
	
	
	//
	
	
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		if(control == null){
			control = Control.getControlador ();
		}
		List <String> list = control.getServers ();
		
		selStrings = new string[list.Count];
		
		for (int i = 0; i < selStrings.Length; i++) {
			
			selStrings [i] = list [i];
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
            GUI.Window(1, mainWindow, getMainWindow, "Editar Servidores : ");
        }
    }

    void getMainWindow(int idWindow)
    {
        
        GUILayout.BeginVertical("box");
           GUILayout.Label("Lista de Servidores : ");
			GUILayout.Space(10.0f);
		
		//grid start
		if (selStrings.Length > 0) {
			selGridInt = GUILayout.SelectionGrid (selGridInt, selStrings, 2, "toggle");
		} else {
			GUILayout.Space (10);
			GUILayout.Label ("No existen Servidores Predefinidos");
			GUILayout.Space (10);
		}
		//grid ends
		
        if(GUILayout.Button("Editar Servidor")){
			
		}
		
		if(GUILayout.Button("Eliminar Servidor")){
			
		}
		
		if(GUILayout.Button("Atras")){
			menu = (ServerMenu)GetComponent(typeof(ServerMenu));
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

