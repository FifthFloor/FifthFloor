using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

namespace Mundo
{/// <summary>
/// Cliente.
/// </summary>
	class Cliente : MonoBehaviour
	{
		/// <summary>
		/// The client.
		/// </summary>
		public static Cliente client = null;
		/// <summary>
		/// The list of servers in main memory.
		/// </summary>
		private List<Server> servers = null;
		/// <summary>
		/// The networkerror is a flag to indicate if the Client was connected successfully.
		/// </summary>
		NetworkConnectionError networkError = NetworkConnectionError.ConnectionFailed;
		/// <summary>
		/// The file that contains all information about servers.
		/// </summary>
		private string fileNameServers = "Servers.Clue";

		/// <summary>
		/// Initializes a new instance of the <see cref="Mundo.Cliente"/> class.
		/// </summary>
		private Cliente ()
		{
			servers = new List<Server> ();
			loadServers();
		}
		
		
		/// <summary>
		/// Gets the cliente.
		/// </summary>
		/// <returns>
		/// The cliente.
		/// </returns>
		public static Cliente getCliente ()
		{
			if (client == null) {
				client = new Cliente ();
			}
			return client;
		}
		/// <summary>
		/// Get the File of name servers.
		/// </summary>
		/// <returns>
		/// The filename with the servers information.
		/// </returns>
		public string getfileNameServers ()
		{
			return fileNameServers;
		}
		
		
		/// <summary>
		/// Connects to the server.
		/// </summary>
		/// <returns>
		/// true whether is connected to the server, false otherwise
		/// </returns>
		/// <param name='servername'>
		/// The name of the server, the "alias"
		/// </param>
		public bool connectServer (string servername)
		{
			Server s;
			for (int i = 0; i < servers.Count; i++) {
				s = servers [i];
				if (s.getAlias ().Equals (servername)) {
					return connect (s.getDireccionIp (), s.getRemotePort ());
				}
			}
			return false;     
		}

		/// <summary>
		/// Connect the specified ip and port.
		/// </summary>
		/// <param name='ip'>
		/// string with the Server Ip Address
		/// </param>
		/// <param name='port'>
		/// Integer (int) with the number of the server port
		/// </param>
		public bool connect (string ip, int port)
		{
			networkError = Network.Connect (ip, port);
			if (networkError == NetworkConnectionError.NoError) {
				//TODO revisar si no hay conexion a servidor donde va este script
				GameObject[] objects = FindObjectsOfType (typeof(GameObject)) as GameObject[];

				foreach (GameObject g in objects) {
					g.SendMessage ("OnNetworkLoadedlevel", SendMessageOptions.DontRequireReceiver);
				}
				return true;
			}
			
			if(networkError == NetworkConnectionError.AlreadyConnectedToServer ||
			   networkError == NetworkConnectionError.AlreadyConnectedToAnotherServer){
				//TODO Exception solo una conexion por vez
				return false;
			}
			
			if(networkError == NetworkConnectionError.ConnectionFailed){
				//TODO Exception conexion fallida con servidor
				return false;
			}
			
			if(networkError == NetworkConnectionError.IncorrectParameters){
				//TODO Exception parametros incorrectos
				return false;
			}
			
			if(networkError == NetworkConnectionError.TooManyConnectedPlayers){
				//TODO Exception esta lleno el servidor 
			}
			
			return false;
		}

		/// <summary>
		/// Disconnect (Release) the connection to the server.
		/// </summary>
		public bool disconnect ()
		{
			Network.Disconnect ();
			return (Network.peerType == NetworkPeerType.Disconnected);
		}
		
		
		/// <summary>
		/// Exit to the application.
		/// </summary>
		/// <returns>
		/// True if application going to quit.
		/// </returns>
		/// 
		public bool salirAplicacion ()
		{
			Application.Quit ();
			return true;
		}
		
		/// <summary>
		/// Saves the server into the "Servers.Clue" file.
		/// </summary>
		/// <returns>
		/// The server.
		/// </returns>
		/// <param name='ip'>
		/// The IP Address of the server.
		/// </param>
		/// <param name='port'>
		/// The server port number.
		/// </param>
		/// <param name='alias'>
		/// The "Nickname" of the server.
		/// </param>
		public bool saveServer (string ip, int port, string alias)
		{
			if(alias == "" || alias == null ){
			alias = "UnNamed";
			}
			FileStream stream = new FileStream (getfileNameServers (), FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter writer = new StreamWriter (stream);
			writer.WriteLine (ip + "-" + port + "-" + alias);
			writer.Close ();
			return true;
		}
		
		/// <summary>
		/// Adds the server to the List of server in main memory  additional it saevs the server in the file of server.
		/// </summary>
		/// <returns>
		/// True if the, server was already added to the list of server in main memory and also the server was succesfully saved into the file of servers.
		/// </returns>
		/// <param name='ip'>
		/// The IP Address of the Server
		/// </param>
		/// <param name='port'>
		/// The port number in the server.
		/// </param>
		/// <param name='Alias'>
		/// The "Nickname" of the server
		/// </param>
		public bool addServer (string ip, int port, string Alias)
		{
			servers.Add (new Server (ip, port, Alias));

			//save into the file
			return saveServer (ip, port, Alias);
           
         
		}

		private void loadServers()
		{
			string temp = "";
			string[] s = null;
			FileStream stream = new FileStream (getfileNameServers (), FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader (stream);

			while (reader.Peek() > -1) {
				temp = reader.ReadLine ();
				s = temp.Split ('-');
				servers.Add (new Server (s [0], Int16.Parse (s [1]), s [2]));
			}
            
			reader.Close ();
		}
		
		public List <Server> getServers ()
		{
			
			return servers;
		}

	}
}
