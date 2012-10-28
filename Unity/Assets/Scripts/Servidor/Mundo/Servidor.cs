using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine; 

namespace Mundo
{
	public class Servidor : MonoBehaviour
	{
        private static Servidor server = null;
        private int numConnections = 0;
        private int port = 0;
        private bool NAT = false;
        private bool onGame = false;

        public Servidor() 
        {
            numConnections = 6;
            port = 5555;
            NAT = Network.HavePublicAddress();
        }
        public static Servidor getServer()
        {
            if (server == null)
            {
                server = new Servidor();
            }
            return server;
        }
        

        public void setPortNumber(int _port)
        {
            port = _port;
        }

        public bool isPublicAddress() 
        {
            return NAT;
        }

        public int getPort() 
        {
            return port;
        }

        public int getNumConnections() 
        {
            return numConnections;        
        }

        public string getJugadores()
        {
            string ret = "";
            NetworkPlayer []  players =  Network.connections;
            NetworkPlayer p;
            for (int i = 0; i < players.Length; i++)
            {
                p = players[i];
                ret = "Jugador Numero " + i + " : " +
                      "Direccion IP : " + p.ipAddress + " \n " +
                      "Numero de Puerto : " + p.port  + " \n ";

            }
            return  ret;
        }

        


        public bool escribirLog(string log) 
        {
        //TODO escribir en log Server

            return false;
        }

        public bool isServer()
        {
            return (Network.peerType == NetworkPeerType.Server);
        }

        public void registrarServidor()
        {
            Network.InitializeServer(getNumConnections(), getPort(),isPublicAddress());

            GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];

            foreach(GameObject g in objects)
            {
                g.SendMessage("OnNetworkLoadedlevel", SendMessageOptions.DontRequireReceiver);
            }
        }

        public string getDireccionIP()
        {
            return Network.player.ipAddress;
        }

        public void DetenerServicios()
        {
         
            Network.Disconnect();
        }

        internal bool isOnGame()
        {
            return onGame;
        }
    }
}
