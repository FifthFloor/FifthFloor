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
    
    
    
     void makeSphere() {

        Network.Instantiate(objeto, transform.position, transform.rotation,0);
    }

    void OnGUI() {

        if (GUILayout.Button("sphere")) 
        {
          //  networkView.RPC("makeSphere",RPCMode.Others);
            makeSphere();
        }
    }
}
