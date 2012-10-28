using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;


namespace Mundo
{
	class Cliente : MonoBehaviour
	{
        public static Cliente cliente;
        private List<Server> servidores;
        NetworkConnectionError networkError;
        private string fileNameServers = "Servers.Clue";

    
        private Cliente()
        {
            servidores = new List<Server>();
            //TODO load servers from file
        }

        public static Cliente getCliente()
        {
            if(cliente==null){
                cliente = new Cliente();
            }
            return cliente;
        }

        public string getfileNameServers() {
            return fileNameServers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servername"></param>
        /// <returns></returns>
        public bool connectServer(string servername)
        {
            Server s;
            for (int i = 0; i < servidores.Count; i++)
            {
                s = servidores[i];
    			if(s.getAlias().Equals(servername)){
					return connect(s.getDireccionIp(), s.getRemotePort());
				}
            }
			return false;
			
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public bool connect(string ip, int port)
        {
            networkError = Network.Connect(ip,port);
		    if(networkError == NetworkConnectionError.NoError){
                //TODO revisar si no hay conexion a servidor dond eva este script
                GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];

                foreach (GameObject g in objects)
                {
                    g.SendMessage("OnNetworkLoadedlevel", SendMessageOptions.DontRequireReceiver);
                }
            return true;
            }
            return false;
        }

        //
        public bool desconectar()
        {
            Network.Disconnect();
            return true;
        }

        public bool salirAplicacion() 
        {
            Application.Quit();
            return true;
        }

        public bool guardarServidor() 
        {

            return true;
        }

        public bool adicionarServidor(string ip, int port, string Alias)
        {
            servidores.Add(new Server(ip,port,Alias));

            //save into the file

            FileStream stream = new FileStream(getfileNameServers(), FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(ip+"-"+port+"-"+Alias);
            writer.Close();
            return true;
        }

        private void cargarListaServidores() {
            string temp = "";
            string[] s = null;
            FileStream stream = new FileStream(getfileNameServers(), FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
               temp = reader.ReadLine();
               s = temp.Split('-');
               servidores.Add(new Server(s[0],Int16.Parse(s[1]),s[2]));
            }
            
            reader.Close();
        }
		
		public List <Server> getServers(){
			
			return servidores;
		}

	}
}
