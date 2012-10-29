using UnityEngine;
using System.Collections;



    public class Vista_ : MonoBehaviour
    {

        //GUI Variables
        public int windowWidth = 388;
        public int windowHeight = 215;
        private UnityEngine.Rect mainWindow;
        private int horizontalCenter;
        private int verticalCenter;
        public GUISkin myskin;
        private bool hideWindow = false;
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
        GUILayout.BeginVertical("box");
        
        if (control.isServer())
        {
            GUILayout.Label("Direccion IP de Servidor : " + control.getDireccionIP());
            GUILayout.Label("Numero de Puerto : "+ control.getPort());
            if (!control.isOnGame()) {
                informationText += "No hay partidas en curso \n";
            }
 
            GUILayout.Box(informationText);
            if (GUILayout.Button("Detener Servicios"))
            {
                control.DetenerServicios();
            }
        }
        else {
            GUILayout.Label("Direccion IP de Servidor : " + control.getDireccionIP());

            GUILayout.BeginHorizontal("box");
            
            GUILayout.Label("Numero de Puerto : ");
            GUILayout.TextField(portNumber);
            GUILayout.EndHorizontal();
            
            if (GUILayout.Button("Iniciar Servicios")) 
            {
                control.registrarServidor();
            }
        
        }
        GUILayout.BeginHorizontal("box");
        if (GUILayout.Button("Ver Clientes")) 
        {
            VistaClientes vc = (VistaClientes)GetComponent("VistaClientes");
            hide();
            vc.show();
        }
        
       if( GUILayout.Button("Ver Scenario") ){
           Application.LoadLevel("RPCTest");
       }
        if(GUILayout.Button("Salir"))
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
