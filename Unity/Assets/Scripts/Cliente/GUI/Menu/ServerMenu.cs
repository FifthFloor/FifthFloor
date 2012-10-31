using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Controlador;

public class ServerMenu : MonoBehaviour
{

	//GUI Variables
	public GUISkin myskin;
	public int windowWidth = 388;
	public int windowHeight = 143;
	private UnityEngine.Rect mainWindow;
	private int horizontalCenter;
	private int verticalCenter;
	private bool hideWindow = true;
	private Vector2 serverScroll = Vector2.zero;
        
	//relationships
	private Menu menu;
	private Control control = null;

	//vars
	private string nicknameText = "";
	public int selGridInt = 0;
	public string[] selStrings = new string[] {};
	// Use this for initialization
	void Awake ()
	{
		control = Control.getControlador ();
		menu = (Menu)GetComponent ("Menu");

	}

	// Update is called once per frame
	void Update (){
		control = Control.getControlador ();
		List <String> list = control.getServers ();
		
		selStrings = new string[list.Count];
		
		for (int i = 0; i < selStrings.Length; i++) {
			
			selStrings [i] = list [i];
		}
	}

	void OnGUI ()
	{
		if (!hideWindow) {
			GUI.skin = myskin;
			//Settings
              
			if (GUI.Button (new Rect (Screen.width - 140, 0, 140, 45), "Opciones")) {
				Settings setting = (Settings)GetComponent ("Settings");
				hide ();
				setting.show ();
			}
			if (menu != null) {

				GUI.Label (new Rect (0, 0, 150, 45), "Bienvenido " + menu.getNickname ());
			} else {
				menu = (Menu)GetComponent ("Menu");

			}
			
			horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
			verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
			mainWindow = new Rect (horizontalCenter, verticalCenter, windowWidth, windowHeight);
			GUI.Window (1, mainWindow, getMainWindow, "Conectar a :");
			//
			GUILayout.Label (nicknameText);
			menu.getNickname ();

			//salir del juego
			if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 40, 150, 40), "Salir del Juego")) {
				Application.Quit ();
			}

		}

	}

	void getMainWindow (int idWindow)
	{
		GUILayout.BeginVertical ("box");
		GUILayout.Label ("Seleccione un servidor ");

		//server List
		//GRID
		if (selStrings.Length > 0) {
			selGridInt = GUILayout.SelectionGrid (selGridInt, selStrings, 2, "toggle");
		} else {
			GUILayout.Space (10);
			GUILayout.Label ("No existen Servidores Predefinidos");
			GUILayout.Space (10);
		}

		GUILayout.BeginHorizontal ("box");



		if (selStrings.Length > 0) {
			if (GUILayout.Button ("Conectar")) {
				string aliasServer = selStrings [selGridInt];
				if (control.connectToServer (aliasServer)) {
					CharacterChooser c = (CharacterChooser)GetComponent ("CharacterChooser");
					hide ();
					c.show ();
				}
			}


			if (GUILayout.Button ("Editar Lista")) {
				ServerEditSettings serverMenu = (ServerEditSettings)GetComponent (typeof(ServerEditSettings));
			}

		} else {
			if (GUILayout.Button ("Añadir Servidor")) {
				ServerSettings serverMenu = (ServerSettings)GetComponent ("ServerSettings");
				hide ();
				serverMenu.show ();
			}
		}

		if (GUILayout.Button ("Atras")) {
			Menu m = (Menu)GetComponent ("Menu");
			hide ();
			m.show ();
		}
		GUILayout.EndHorizontal ();
		GUILayout.EndVertical ();

	}

	public void show ()
	{
		hideWindow = false;
	}

	public void hide ()
	{
		hideWindow = true;
	}

	public void loadServers ()
	{
    
	}
}
