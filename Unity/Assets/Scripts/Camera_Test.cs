using UnityEngine;
using System.Collections;

public class Camera_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	camera.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Show(){
		
		camera.enabled = true;
	}
}
