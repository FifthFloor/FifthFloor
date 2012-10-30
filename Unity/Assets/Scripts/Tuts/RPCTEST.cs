using UnityEngine;
using System.Collections;

public class RPCTEST : MonoBehaviour {
    public GameObject objeto;
    
    private bool flag = true;
	// Use this for initialization
	void Start () {
        
	}

    void OnNetworkInstantiate(NetworkMessageInfo info)
    {
        Debug.Log(networkView.viewID + " spawned"); 
        if (Network.isServer) 
        { Network.RemoveRPCs(networkView.viewID);
            Network.Destroy(gameObject); 
        } 
    }
	// Update is called once per frame
	void Update () {
	}



  
    void makeSphere()
    {
        if (networkView.isMine)
        {
            Network.Instantiate(objeto, transform.position, transform.rotation, 0);
        }
    }

    void OnGUI() {
        
        if (flag)
        {
            if (GUILayout.Button("First person Controller"))
            {
                //  networkView.RPC("makeSphere",RPCMode.Others);
                makeSphere();
                flag = !flag;
            }
            
        }
    }
}
