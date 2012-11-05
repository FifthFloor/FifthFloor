using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mundo;
namespace Controlador
{
	class Controller
	{
        private static Controller control = null;
        private Servidor server = null;

        private Controller() 
        {
            server = Servidor.getServer();
        }

        public int getPort() 
        {

            return server.getPort();
        }
        public static Controller getControlador()
        {
            if(control == null )
            {
                control = new Controller();
            }
            return control;
        }

        public string getJugadores() {
            return server.getJugadores();
        }


        public bool isServer()
        {
            return server.isServer();
        }

        internal void registrarServidor()
        {
            server.registrarServidor();
        }

        public string getDireccionIP()
        {
            return server.getDireccionIP();
        }

        public void DetenerServicios()
        {
            server.DetenerServicios();
        }

        internal bool isOnGame()
        {
            return server.isOnGame();
        }

		public void OnConnectedToServer ()
		{
			server.OnConnectedToServer();
		}

		public void OnServerInitialized ()
		{
			server.OnServerInitialized();
		}

      
    }
}
