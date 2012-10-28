using UnityEngine;
using System.Collections;
using System;
public class Server_init : MonoBehaviour {
	
	public int windownWidth = 500;
	public int windownHeight = 500;
	public int listenPort = 25000;
	private bool usingNAT = false;
	public int numConnections = 6;
	private string textAreaString = " Log \n";
	private string clients = "Listado de Clientes "+ "\n";
	private Vector2 scrollPosition =  Vector2.zero;
	//private bool ServerServices = false;
	private bool stopServices   = false;
    private bool hideWindow     = false;
    private Chat chat = new Chat();
	
	// Use this for initialization
	void Awake () {
        AudioListener.volume = 0.0f;
		if(Network.HavePublicAddress()){
		textAreaString += "IP Publica \n";
	
		}else{
			textAreaString +="IP Privada";
		}	
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	#region GUI

    void OnGUI()
    {
        if (!hideWindow)
        {
            GUI.Window(1, new Rect(20, 20, windownWidth, windownHeight), getMainWindow, " Iniciar Servidor ");
        }
    }

    public void hide()
    {
        hideWindow = true;
    }

   public void showWindow()
    {
        hideWindow = false;
    }

	void getMainWindow(int WindowID){
		
	
	//Vertical Group
	GUILayout.BeginVertical("box");
		
	    GUILayout.Label("Listen Port");
		listenPort = System.Int16.Parse(GUILayout.TextField(listenPort+""));
		
		GUILayout.Label("Allowed Connections");
		numConnections = System.Int16.Parse(GUILayout.TextField(numConnections+""));
		
		
		//Horizontal Group
		GUILayout.BeginHorizontal("box");
		
		if(!stopServices){
			if(GUILayout.Button("Start Server")){
				launchServer();
				print ("launch Server");
				stopServices = true;
			}
		}else{
			if(GUILayout.Button("Stop Server")){
				stopServer();
				stopServices = false;
			}
		}

		if(GUILayout.Button("Check Clients")){
			NetworkPlayer[] np = Network.connections;
			NetworkPlayer p;

            clients = "Listado de Clientes : [ " + DateTime.Now + " ]" + "\n";
			clients+= "Existen [ "+ np.Length +" ] Clientes Conectados" + "\n";
			for(int i=0;i<np.Length;i++)
			{
			p=np[i];
			clients+= "IP - " + p.ipAddress + "\n";
			clients+= "Puerto - " + p.port + "\n";
			clients+= "External IP"+ p.externalIP + "\n";
			clients+= "External Port"+ p.externalPort +"\n";
			}
		}
		
		GUILayout.EndHorizontal();
				
		//Displays the information about clients connected to the server
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width (420), GUILayout.Height (100));
		GUILayout.TextArea(clients,GUILayout.Width(400));
		GUILayout.EndScrollView();

        if(GUILayout.Button("Start Chat")){
            //llamada a otro script
            //otherObject.GetComponent<NameOfScript>().enabled = false;
            hide();
            UnityEngine.Component component = GetComponent("Chat");
            chat = (Chat)component;
            chat.showWindow();
        }
		
	GUILayout.EndVertical();
	//End Vertical Group
	}
	
	#endregion
	
	#region Methods
	
	void launchServer()
    {
		usingNAT = !Network.HavePublicAddress();
		Network.InitializeServer(numConnections,listenPort,usingNAT);
		MasterServer.RegisterHost("Clue","FifthFloor","Game 4 ALL");
		textAreaString += "Launch Server ";
		if(Network.isServer){
			   print ("Servidor de Red");
			}else{
			print ("no esta en modo servidor");
			}
	}
	
	//Disconnect the Server
	void stopServer(){
	
	Network.Disconnect();
	}
	
	#endregion

}
