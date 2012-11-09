using UnityEngine;
using System.Collections;

public class PopUps : MonoBehaviour
{
	//GUI
	public bool hideWindow = false;
	public float buttonWidth = 30;
	public float buttonHeight = 30;
	private float aux;
	//script
	public Rect HistoryRect = new Rect ();

	void Start ()
	{
		HistoryRect = new Rect (Screen.width - buttonWidth, Screen.height - buttonHeight, buttonWidth, buttonHeight);
	}

	void OnGUI ()
	{
		if (!isHide ()) {
			if(GUILayout.Button("Historial")){
				MainScreen m = (MainScreen) FindObjectOfType(typeof(MainScreen));
				hide ();
				m.show();
			}
		}
	}

	public bool isHide ()
	{
		return hideWindow;
	}

	public void hide ()
	{
		hideWindow = true; 
	}

	public void show ()
	{
		hideWindow = false;
	}
}
