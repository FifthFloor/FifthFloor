using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Mundo;

namespace Controlador
{
/// <summary>
/// Controller the client.
/// </summary>
    class Control
    {
		/// <summary>
		/// The controller.
		/// </summary>
        private static Control control = null;
		/// <summary>
		/// The cliente instance.
		/// </summary>
        private Cliente cliente;

		/// <summary>
		/// Initializes a new instance of the <see cref="Controlador.Control"/> class.
		/// </summary>
        private Control()
        {
          cliente = Cliente.getCliente();
        }
		
		/// <summary>
		/// Gets the controlador.
		/// </summary>
		/// <returns>
		/// The controlador.
		/// </returns>
        public static Control  getControlador()
        {
            if (control == null) 
            {
                control = new Control();
            }
            return control;
        }

		/// <summary>
		/// Connects to server.
		/// </summary>
		/// <returns>
		/// True if the client was succefully connected to the server.
		/// </returns>
		/// <param name='IpAddress'>
		/// The IPAddress of the server
		/// </param>
		/// <param name='port'>
		/// The port number in the server
		/// </param>
        public bool connectToServer(String IpAddress, int port)
        {
            return cliente.connect(IpAddress, port);
        }
	
		/// <summary>
		/// Connects to server.
		/// </summary>
		/// <returns>
		/// True if the connection to the server was successful.
		/// </returns>
		/// <param name='alias'>
		/// A given "alias"or "Nickname" to a server
		/// </param>
		public bool connectToServer(string alias)
		{
			return cliente.connectServer(alias);
		}
		
		/// <summary>
		/// Disconnect this instance to the server already connected.
		/// </summary>
        public bool disconnect()
        {
            return cliente.disconnect();
           
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
            return cliente.addServer(ip, Int16.Parse(port), alias);
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

