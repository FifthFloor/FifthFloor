using UnityEngine;
using System.Collections;

public class MouseSettings : MonoBehaviour {
	
	void Awake(){
        //ParticleSystem p = (ParticleSystem)GetComponent(typeof(ParticleSystem));
       // p.enableEmission = false;
		//this.particleEmitter.enabled=false;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
          //  this.particleEmitter.enabled=true;
			
            Debug.Log("Pressed left click.");
           
           // transform.particleSystem.enableEmission = true;
          //  ParticleSystem p = (ParticleSystem)GetComponent(typeof(ParticleSystem));
           // p.enableEmission = true;
            
        }
            if (Input.GetMouseButton(1)) Debug.Log("Pressed right click."); 
        if (Input.GetMouseButton(2)) Debug.Log("Pressed middle click.");
	}
}
