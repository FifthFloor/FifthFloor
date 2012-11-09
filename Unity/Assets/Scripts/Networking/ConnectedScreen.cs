using UnityEngine;
using System.Collections;

public class ConnectedScreen : MonoBehaviour
{
	public  bool isConnected;

	
	//GUI
	 //GUI Variables
    private float windowWidth = 0;
    private float windowHeight = 0;
    public float windowHeightMax = Screen.height;
    public float windowWidhtMax = Screen.width;

    private UnityEngine.Rect mainWindow;
    private int horizontalCenter;
    private int verticalCenter;
    public GUISkin myskin;
    private bool hideWindow = true;
    public float popUpSpeed = 18;
	private string msg = "Se Ha perdido la Conexion con el Servidor" ;
	//script

	void Start ()
	{
		//TODO desabilitar todos los scripts de la camara 
		//FIXME si se abre y no estan desactivados los demas scripts exception
	}

	void Update ()
	{
		if (Network.peerType.Equals(NetworkPeerType.Disconnected)) {
			isConnected = false;
		} else {
			isConnected = true;
		}
	}
	  void FixedUpdate()
    {
        if (!isConnected)
        {
            OpenPopUp();
        }else{
			closePopUp();
		}
		
    }
	
	void OnGUI ()
	{
		if (!isConnected) {
			GUI.skin = myskin;
            horizontalCenter = (int)(((Screen.width / 2) - (windowWidth / 2)));
            verticalCenter = (int)((Screen.height / 2) - (windowHeight / 2));
            mainWindow = new Rect(horizontalCenter, verticalCenter, windowWidth, windowHeight);
            GUI.Window(1, mainWindow, getMainWindow, " Informacion ");
		}
	}
	
	
    void getMainWindow( int idWindow )
    {

        GUILayout.BeginVertical("box");
      
        GUILayout.Label(msg);
		GUILayout.Label("Desea reconectar con el servidor");
				GUILayout.BeginHorizontal();
				GUILayout.Button("Si");
				GUILayout.Button("No");
				GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");

   		if (GUILayout.Button("Cerrar", "button"))
            {
                closePopUp();
            }
   
            GUILayout.EndHorizontal();

        GUILayout.EndVertical();

    }

	public bool isHide ()
	{
		return hideWindow;
	}

	public void hide ()
	{
		hideWindow = true; 
	}

	public void show ()
	{
		hideWindow = false;
	}
	
	 private void OpenPopUp()
    {
        if (windowHeight <= windowHeightMax)
        {
            windowHeight = (windowHeight + popUpSpeed);
        }
        if (windowWidth <= windowWidhtMax)
        {
            windowWidth = (windowWidth + popUpSpeed);
        }
    }

    private void closePopUp()
    {
         if (windowHeight >= 0)
        {
            windowHeight = (windowHeight - popUpSpeed);
        }
        if (windowWidth >= 0)
        {
            windowWidth = (windowWidth - popUpSpeed);
        }
    }
}
