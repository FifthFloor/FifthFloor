using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterChooser : MonoBehaviour
{
    //GUI Variables
    public int windowWidth = 623;
    public int windowHeight = 301;
    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    public GUISkin myskin;
    private bool hideWindow = true;

    //relationships
    //Controlador.Controller control;
    //Images
    public Texture2D character1;
    public Texture2D character2;
    public Texture2D character3;
    public Texture2D character4;
    private Controlador.Control control;

    // Use this for initialization
    void Awake() {
        
    }
    void Start()
    {
        control = Controlador.Control.getControlador();
      //  portNumber = System.Convert.ToString(control.getPort());
       // informationText = "Conexiones con Clientes : " + Network.connections + "\n";
    }

    // Update is called once per frame
    void Update()
    {
    //    portNumber = System.Convert.ToString(control.getPort());
    }

    void OnGUI()
    {
        if (!hideWindow)
        {
           
            GUI.skin = myskin;
            
            horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
            verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
            mainWindow = new Rect(horizontalCenter, verticalCenter, windowWidth, windowHeight);
            GUI.Window(1, mainWindow, getMainWindow, "Selección de Jugador");

            if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 70, 150, 70), "Desconectar de Servidor"))
            {
                if (control.disconnect()) { 
               
                    //TODO mostrar pantalla de abandono de partida
                
                }
            }

        }
    }

    void getMainWindow(int idWindow)
    {
        GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            GUILayout.Button(character1,GUILayout.Height(200f),GUILayout.Width(150f));
            GUILayout.Button(character2,GUILayout.Height(200f),GUILayout.Width(150f));
            GUILayout.Button(character3,GUILayout.Height(200f),GUILayout.Width(150f));
            GUILayout.Button(character4,GUILayout.Height(200f),GUILayout.Width(150f));
            GUILayout.EndHorizontal();
      

       
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Aceptar")) 
        {
           
            Application.LoadLevel("RPCTest");
            
        }
        if(GUILayout.Button("Atras"))
        {
        
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
