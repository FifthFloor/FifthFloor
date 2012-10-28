using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {
	
	public Texture2D icon;
	
	private string textFieldString = "TextField Example";
	private string textAreaString  = "Text Area Example";
	private bool toggleExample = false;
	private float hSliderValue = 0.0f;
	private float vSliderValue = 0.0f;
	private Vector2 scrollViewVector = Vector2.zero;
	private string innerText = "I am inside the ScrollView";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		
		GUI.Box(new Rect(10,10,780,800),"CLUE - Do You Fear Death?" );
		
		if(GUI.Button(new Rect(320,60,110,45),icon)){
			//
			Application.Quit();
		}
		//RECT  X position in Screen,Y position in Screen, Height in Screen,Width, Height
		if(GUI.Button(new Rect(320,120,110,45),new GUIContent("Iniciar Juego",icon,"Tooltip"))){
			//Print Shows information in Console
			//Application.LoadLevel(1);
			
		}
		
		if(GUI.Button(new Rect(320,170,110,45),"Salir")){
			//
			Application.Quit();
		}
		
		if(GUI.RepeatButton(new Rect(320,220,110,45),new GUIContent("RepeatButton",icon,"Tooltip"))){
		
		}
		
		//Toogle Button
		
		toggleExample = GUI.Toggle (new Rect (320, 460, 100, 30), toggleExample, "Toggle");
	
			
		//label Example
		GUI.Label(new Rect(320,270,100,45)," Label Example ");
		
		//TextField Example
		textFieldString = GUI.TextField(new Rect(320,300,200,55),textFieldString);
		
		//TextArea Example
		textAreaString = GUI.TextArea(new Rect(320,365,250,70),textAreaString);
		
		//Horizontal Slider
		hSliderValue = GUI.HorizontalSlider (new Rect (25, 25, 100, 30), hSliderValue, 0.0f, 10.0f);
		
		//Vertical Slider
		vSliderValue = GUI.VerticalSlider (new Rect (25, 60, 100, 70), vSliderValue, 10.0f, 0.0f);
		
		
		//
		//_________________________________________________
		//
		// Begin the ScrollView
		scrollViewVector = GUI.BeginScrollView (new Rect (70, 95, 100, 100), scrollViewVector, new Rect (0, 0, 400, 400));

		// Put something inside the ScrollView
		innerText = GUI.TextArea (new Rect (0, 0, 400, 400), innerText);

		// End the ScrollView
		GUI.EndScrollView();
		
		//-------------------------------
		
		
		
		
	}
}
