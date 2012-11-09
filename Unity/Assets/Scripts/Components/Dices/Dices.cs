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
	void FixedUpdate () {
        if (flag)
        {
            System.Random r = new System.Random();

            int end = DateTime.Now.Second;
            if ((end - sec) >= 0.8)
            {
                transform.Translate(r.Next(1), r.Next(1), r.Next(1));
                transform.rigidbody.useGravity = true;
                if ((end - sec) >= 2)
                {

                    transform.rigidbody.useGravity = true;
                    flag = false;
                }

            }

            transform.Rotate(10.0f, 16.0f, 22.0f);

        }
        else
        {
         
            
        }
	}

 

    public void Rotate() {
        flag = true;
         sec = DateTime.Now.Second;
         Camera c = (Camera)FindObjectOfType(typeof(Camera));
         Dices d = (Dices)FindObjectOfType(typeof(Dices));
         c.transform.LookAt(d.transform);
    }

   
}
