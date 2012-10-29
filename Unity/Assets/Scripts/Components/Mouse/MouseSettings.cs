using UnityEngine;
using System.Collections;

public class MouseSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            this.particleEmitter.Emit(300);
            Debug.Log("Pressed left click.");
        }
            if (Input.GetMouseButton(1)) Debug.Log("Pressed right click."); 
        if (Input.GetMouseButton(2)) Debug.Log("Pressed middle click.");
	}
}
