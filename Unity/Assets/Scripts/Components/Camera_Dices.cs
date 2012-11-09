using UnityEngine;
using System.Collections;

public class Camera_Dices : MonoBehaviour
{
	public Transform Objetivo = null;
	private Vector3 Target = Vector3.zero;
	private bool CambiarFlag = false;
	Vector3 posicionActual = Vector3.zero;
	public GUISkin mySkin;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Objetivo != null && CambiarFlag) {
			Target = Objetivo.position;
			Camera c = (Camera)FindObjectOfType (typeof(Camera));
			posicionActual = c.transform.position;

			MoverCamara ();

		}
	}
	
	private void MoverCamara ()
	{
		if (CambiarFlag) {
			Camera c = (Camera)FindObjectOfType (typeof(Camera));
			c.transform.position = Target;
			c.transform.rotation = Objetivo.rotation;
			CambiarFlag = false;
		}
	}

	void OnGUI ()
	{
		GUI.skin = mySkin;
	  	
		MouseLook mouse = (MouseLook) GetComponent(typeof(MouseLook));
			mouse.enabled = false;
		if (GUILayout.Button ("Blue Spawn")) {
			searchTarget ("Blue Spawn", "Blue_spawnPoint");
			
			mouse.enabled = true;
		}
		if (GUILayout.Button ("Green Spawn")) {
			searchTarget ("Green Spawn", "Green_spawnPoint");
			
			mouse.enabled = true;
		}
		if (GUILayout.Button ("Red Spawn")) {
			searchTarget ("Red Spawn", "Red_spawnPoint");
			
			mouse.enabled = true;
		}
		if (GUILayout.Button ("Purple Spawn")) {
			searchTarget ("Purple Spawn", "Purple_spawnPoint");
			
			mouse.enabled = true;
		}
		if (GUILayout.Button ("Yellow Spawn")) {
			searchTarget ("Yellow Spawn", "yellow_spawnPoint");
			
			mouse.enabled = true;
		}
		if (GUILayout.Button ("White Spawn")) {
			searchTarget ("White Spawn", "White_spawnPoint");
			
			mouse.enabled = true;
		}
		if (GUILayout.Button ("Ver Dados")) {
			searchTarget ("Vista_Dados", null);
			//lanza dados
			Dices[] d = (Dices[])FindObjectsOfType (typeof(Dices));
			foreach (Dices die in d) {
				die.Rotate ();
			}

		}
		if(GUILayout.Button("Test Suggestion")){
			
			mouse.enabled = false;
			searchTarget ("SuggestionPoints", "Suggestion_Dungeon");
			Suggestion s = (Suggestion)FindObjectOfType(typeof(Suggestion));
			s.show();

		}
		if (GUILayout.Button ("Change Camera")) {
			//searchTarget ("Character_camera", "White_spawnPoint");
			Camera[] test =(Camera[]) FindObjectsOfType(typeof(Camera));
			foreach(Camera c in test)
			{
				if(c.name == "Camera_Character")
				{
				camera.enabled = false;
				c.enabled = true;
				}
			}
			
			
			
		}
	}

	void searchTarget (string _transformName, string _transformPoint)
	{
		Camera c = (Camera)FindObjectOfType (typeof(Camera));
		Object [] t = FindObjectsOfType (typeof(Transform));
		foreach (Transform trans in t) {
			if (trans.name == _transformName) {
				if (trans.GetChildCount() > 0) {
					Component[] childs = trans.GetComponentsInChildren (typeof(Transform));
					foreach (Transform child in childs) {
						if (child.name == _transformPoint) {
							Objetivo = child;					
							CambiarFlag = true;
							break;
						}
					}
				} else {
					Objetivo = trans;					
					CambiarFlag = true;
					break;
					
				}
			}
		}
	}

}
