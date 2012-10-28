using UnityEngine;
using System.Collections;

public class RPCTEST : MonoBehaviour {
    public GameObject objeto;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    
    [RPC]
     void makeSphere() {

        Instantiate(objeto, transform.position, transform.rotation);
    }

    void OnGUI() {

        if (GUILayout.Button("sphere")) 
        {
            networkView.RPC("makeSphere",RPCMode.Server);
           
        
        }
    }
}
