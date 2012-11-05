using UnityEngine;
using System.Collections;
using System;

public class Dices : MonoBehaviour {
    public Boolean flag = false;
    private int sec = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            
            int end = DateTime.Now.Second;
            if ((end - sec) >= 0.8)
            {
                transform.rigidbody.useGravity = true;
                if ((end - sec) >= 2)
                {
					 transform.rigidbody.useGravity = true;
                    flag = false;
                }
                
            }

            transform.Rotate(10.0f, 16.0f, 22.0f);
        }
	}

    public void Rotate() {
        flag = true;
         sec = DateTime.Now.Second;
    }

}
