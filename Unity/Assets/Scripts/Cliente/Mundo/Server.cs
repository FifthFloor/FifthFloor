using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Mundo
{
    class Server
    {
        private string direccionIp = null;
        private int remotePort = 5555;
        private string alias = null;


        /// <summary>
        /// 
        /// </summary>
        public Server()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dirIP"></param>
        /// <param name="remoteP"></param>
        /// <param name="alias"></param>
        public Server(string dirIP, int remoteP, string alias)
        {
            this.direccionIp = dirIP;
            this.remotePort = remoteP;
            this.alias = alias;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public Server(Server s)
        {
            this.direccionIp = s.getDireccionIp();
            this.remotePort = s.getRemotePort();
            this.alias = s.getAlias();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getDireccionIp()
        {
            return direccionIp;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        public void setDireccionIp(string ip)
        {
            this.direccionIp = ip;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getRemotePort()
        {
            return remotePort;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        public void setDireccionIp(int port)
        {
            this.remotePort = port;
        }

        public string getAlias()
        {
            return alias;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        public void setAlias(string alias)
        {
            this.alias = alias;
        }

    }
}