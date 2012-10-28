using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {
    public string ServersFile = "serverList.Clue";

    private string serverList = "";


	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadServers(){
    
    }

    public string getServerList()
    {
        return serverList;
    }
}
