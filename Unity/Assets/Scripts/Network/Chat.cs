using UnityEngine;
using System.Collections;

public class Chat : MonoBehaviour {

    public int windownWidth  = 500;
    public int windownHeight = 500;
    public bool hideWindow   = true;
    public Rect windowRect;
    private Vector2 scrollChatPosition = Vector2.zero;
    private string chatText  = "";
    private string msgtext   = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {

        if (!hideWindow)
        {
            GUILayout.Window(2, new Rect(20,20, windownWidth, windownHeight), getMainWindow, " ------> Chat <------ ");
        }
    }

    void getMainWindow(int iWindow)
    {

        // Vertical Group
        GUILayout.BeginVertical("box");
        scrollChatPosition = GUILayout.BeginScrollView(scrollChatPosition, GUILayout.Width(400), GUILayout.Height(300));
        chatText = GUILayout.TextArea(chatText, GUILayout.Width(360), GUILayout.Height(360));
        GUILayout.EndScrollView();
            GUILayout.BeginVertical("box");

            msgtext = GUILayout.TextField(msgtext);
                    GUILayout.BeginHorizontal("box");

                    if(GUILayout.Button("Enviar")){
                        chatText += msgtext + "\n";//TODO con fecha y nombre de usuario

                        msgtext = "";
                    }
        
                    if (GUILayout.Button("Borrar"))
                    {
                        msgtext = "";
                    }
                    GUILayout.EndHorizontal();

                    if (GUILayout.Button("Atras"))
                    {
                        hide();
                        UnityEngine.Component serverGUI = GetComponent("Server_init");
                        Server_init gui = (Server_init) serverGUI;
                        gui.showWindow();
                    }
               GUILayout.EndVertical();
            //end Vertical Group
        GUILayout.EndVertical();
    }

   public void hide()
    {
        hideWindow = true;
    }

    public void showWindow()
    {
        hideWindow = false;
    }


    [RPC]
    void printText(string text)
    {
        chatText += text + "\n";
    }
}
