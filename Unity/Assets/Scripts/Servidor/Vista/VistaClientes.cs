using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


    public class VistaClientes : MonoBehaviour
    {

        //GUI Variables
        public int windowWidth = 388;
        public int windowHeight = 180;
        private UnityEngine.Rect mainWindow;
        private int horizontalCenter;
        private int verticalCenter;
        public GUISkin myskin;
        private bool hideWindow = true;
        private string informationText;
        private string portNumber;
        //
        Controlador.Controller control;

        void Awake()
        {
            control = Controlador.Controller.getControlador();
        }

        // Use this for initialization
        void Start()
        {
            portNumber = System.Convert.ToString(control.getPort());
            informationText = "Conexiones con Clientes : " + Network.connections + "\n";
        }

        // Update is called once per frame
        void Update()
        {
            portNumber = System.Convert.ToString(control.getPort());
        }

        void OnGUI()
        {
            if (!hideWindow)
            {
                GUI.skin = myskin;
                horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
                verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
                mainWindow = new Rect(horizontalCenter, verticalCenter, windowWidth, windowHeight);
                GUI.Window(1, mainWindow, getMainWindow, "Información de Servidor");
            }
        }

        void getMainWindow(int idWindow)
        {
            informationText = "Conexiones con Clientes : " + Network.connections.Length + "\n";

            for (int i = 0; i < Network.connections.Length; i++)
            {
                informationText += "Cliente No. " + (i + 1) + "\n";
                informationText += "Direccion IP" + Network.connections[i].ipAddress + "\n";
                informationText += "Puerto de Conexion" + Network.connections[i].port + "\n";
            }

            GUILayout.BeginVertical("box");
            GUILayout.TextArea(informationText);
            GUILayout.BeginHorizontal("box");

            if (GUILayout.Button("Atras"))
            {
                Vista_ v = (Vista_)GetComponent("Vista_");
                hide();
                v.show();

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
