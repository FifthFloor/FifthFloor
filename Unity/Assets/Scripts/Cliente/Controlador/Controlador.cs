using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Mundo;
namespace Controlador
{

    class Control
    {
        private static Control control = null;
        private Cliente cliente;

        private Control()
        {
          cliente = Cliente.getCliente();
        }

        public static Control  getControlador()
        {
            if (control == null) 
            {
                control = new Control();
            }
            return control;
        }

        public bool conectarAServidor(String direccionIp, int port)
        {
			
            return cliente.connect(direccionIp, port);

        }
	
		public bool conectarAServidor(string alias)
		{
			return cliente.connectServer(alias);
		}
		
        public bool desconectarDeServidor()
        {
            return cliente.desconectar();
           
        }

        public bool moverJugador()
        {

            return false;
        }

        public bool realizarAcusación()
        {
            return false;
        }

        public bool realizarSugerencia()
        {
            return false;
        }

        public bool realizarAnotacion(String anotacion)
        {
            return false;
        }

        public bool RevelarCarta()
        {
        
            //TODO revelarCartaControlador
            return false;
        }

        public bool abandonarPartida(String anotacion)
        {
            //TODO abandonarPartida Controlador
            return false;
        }

        public bool salirAplicacion()
        {
            cliente.salirAplicacion();
            return false;
        }

        public bool adicionarServidor(String ip,String port, String alias)
        {
            return cliente.adicionarServidor(ip, Int16.Parse(port), alias);
        }
		
		public List<String> getServers(){
			List<Server> servers =cliente.getServers();
			List<string> r = new List<string>();
			foreach (Server s in servers)
			{
				r.Add(s.getAlias());
			}
			
			return r;
		}

     
    }
}

