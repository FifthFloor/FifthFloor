using UnityEngine;
using System.Collections;
using System;

public class Client_init : MonoBehaviour {

	public string hostIP="localhost";
	public int remotePort = 25000;
	public int windownWidth = 500;
	public int windownHeight = 500;
	private Vector2 scrollPosition =  Vector2.zero;
	private bool stopServices = false;
    private DateTime nowTime = DateTime.Now;
	//Connection Status
	NetworkConnectionError networkError = NetworkConnectionError.NoError;
	
	//Music Volume Control
	float musicVolume = 50.0f;
	float musicLowerValue = 0.0f;
	float musicHighestValue = 100.0f;
	
	
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	#region  GUI
	
	void OnGUI(){
		GUI.Window(1,new Rect(20,20,windownWidth,windownHeight),getMainWindow," Iniciar Cliente - CLUE "); 	
	}
	
	
	
	void getMainWindow(int WindowID){
		
	//Vertical Group
	GUILayout.BeginVertical("box");
		
		//IP remote Host
		GUILayout.Label("Server Address");
		hostIP= GUILayout.TextField(hostIP);
		
		GUILayout.Label("Remote Port");
		remotePort = System.Int16.Parse(GUILayout.TextField(remotePort+""));
		
		
		//Horizontal Group
		GUILayout.BeginHorizontal("box");

	    //Starts the connection from client to Server through Host IP-Address and remote port on it;	
		if(!stopServices){
		if(GUILayout.Button("Iniciar Cliente")){
			launchClient();
		}
		}else{
		if(GUILayout.Button("Detener Cliente")){
			stopClient();
		}
		}
		//end Horizontal Group
		GUILayout.EndHorizontal();
	
	GUILayout.Label("Tiempo de Juego : "+ Time.time.ToString());
		
	
		
	GUILayout.EndVertical();	
	//end Vertical Group
		GUILayout.BeginVertical("box");
		GUILayout.Label("Music Volume ");
		musicVolume = GUILayout.HorizontalSlider(musicVolume,musicLowerValue,musicHighestValue);
		AudioListener.volume =musicVolume/100;
		GUILayout.EndVertical();
	}
	#endregion
	
	#region Methods
	
	void launchClient(){
		
	
	networkError.ToString();
		
	}
	
	void stopClient(){
		Network.Disconnect();
	}
	
	#endregion
}
