using UnityEngine;
using System.Collections;

public class Suggestion : MonoBehaviour
{
	
	//GUI Variables
	public int windowWidth  = 388;
	public int windowHeight = 143;
	private UnityEngine.Rect mainWindow;
	private int horizontalCenter;
	private int verticalCenter;
	public GUISkin myskin;
	private bool hideWindow = true;
	
	//CharacterArea
	public Rect  characterArea       = new Rect ();
	public float characterLeftInit   = 14f;
	public float characterTopInit    = 30f;
	public float characterAreaWidth  = 400f;
	public float characterAreaHeight = 400f;
	
	//WeaponArea
	public Rect  weaponArea       = new Rect ();
	public float weaponLeftInit   = 600f;
	public float weaponTopInit    = 230f;
	public float weaponAreaWidth  = 400f;
	public float weaponAreaHeight = 600f;
	
	//ButtonArea
	public Rect  buttonArea 	  = new Rect ();
	public float buttonLeftInit   = 600f;
	public float buttonTopInit    = 630f;
	public float buttonAreaWidth  = 400f;
	public float buttonAreaHeight = 600f;
	
	//Characters Picture
	public Texture2D Sparrow;
	public Texture2D Will;
	public Texture2D Calipso;
	public Texture2D Barbosa;
	public Texture2D Elizabeth;
	public Texture2D Unknown;//TODO cual es el Personaje?
	
	//Weapons Picture
	public Texture2D sword;
	public Texture2D bottle;
	public Texture2D knife;
	public Texture2D rifle;
	public Texture2D poison;
	public Texture2D kraken;
	
	//prefabs to instantiate characters
	public Transform SparrowMesh;
	public Transform WillMesh;
	public Transform CalipsoMesh;
	public Transform BarbosaMesh;
	public Transform ElizabethMesh;
	public Transform UnknownMesh;
	
	//prefabs to instantiate weapons
	public Transform SwordMesh;
	public Transform KnifeMesh;
	public Transform BottleMesh;
	public Transform RifleMesh;
	public Transform PoisonMesh;
	public Transform KrakenMesh;
	
	
	// Use this for initialization
	void Start ()
	{
		
		//Character Area init
		characterAreaWidth = Screen.width - 100;
		characterAreaHeight = 170f;	
		characterArea = new Rect (characterLeftInit, characterTopInit, characterAreaWidth, characterAreaHeight);
		
		
		//Weapon Area init
		weaponAreaWidth = 400;
		weaponAreaHeight = Screen.height;
		weaponLeftInit = Screen.width - weaponAreaWidth;
		weaponArea = new Rect (weaponLeftInit, weaponTopInit, weaponAreaWidth, weaponAreaHeight);
		
		
		//Button Area Init
		buttonAreaWidth  = 400;
		buttonAreaHeight = 170f;	
		buttonTopInit    = Screen.height - 100f;
		buttonLeftInit   = 100f;
		buttonArea = new Rect (buttonLeftInit, buttonTopInit, buttonAreaWidth, buttonAreaHeight);
		
	}


	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
	void OnGUI ()
	{
		if (!hideWindow) 
		{
		//Characters
			GUILayout.BeginArea (characterArea);
				
			GUILayout.Label ("Personaje Acusado");
				
			GUILayout.BeginHorizontal ();
				
				Transform target = searchTarget ("Instantiate_Points", "Dungeon_Instantiate_Point");
				
				if (GUILayout.Button (Sparrow)) 
				{
					//instantiate mesh
					Instantiate (SparrowMesh, target.position, target.rotation);
				}
				
				if (GUILayout.Button (Will)) 
				{
					//instantiate mesh
					Instantiate (WillMesh, target.position, target.rotation);
				}
				
				if (GUILayout.Button (Calipso)) 
				{
					
				}
				
				if (GUILayout.Button (Barbosa)) 
				{
					
				}
				
				if (GUILayout.Button (Elizabeth))
				{
					
				}
				
				if (GUILayout.Button (Unknown)) 
				{
					
				}
				
			GUILayout.EndHorizontal ();
			
			GUILayout.EndArea ();
		//EndCharacters
			
		//Weapons
		GUILayout.BeginArea (weaponArea);
			
		GUILayout.BeginVertical ();
			
			GUILayout.BeginHorizontal ();
			
				if (GUILayout.Button (sword, "toggle")) 
				{
					
				}
				
				if (GUILayout.Button (bottle, "toggle")) 
				{
					
				}
			
			GUILayout.EndHorizontal ();
			
			GUILayout.BeginHorizontal ();
			
				if (GUILayout.Button (knife, "toggle")) 
				{
				
				}
			
				if (GUILayout.Button (rifle, "toggle")) 
				{
				
				}
			
			GUILayout.EndHorizontal ();
			
			GUILayout.BeginHorizontal ();
			
				if (GUILayout.Button (poison, "toggle")) 
				{
					
				}
				if (GUILayout.Button (kraken, "toggle")) 
				{
					
				}
			
			GUILayout.EndHorizontal ();
				
			GUILayout.EndArea ();
		//EndWeapons
			
		//Accusation & suggestion
			GUILayout.BeginArea (buttonArea);
				GUILayout.BeginHorizontal();
				if(GUILayout.Button("Acusar"))
				{
					PopUpSuggestion pop = (PopUpSuggestion) FindObjectOfType(typeof(PopUpSuggestion));
					hide();
					if( pop != null )
					{
						pop.show();
					}
				
				}
			
				if(GUILayout.Button("Realizar Sugerencia"))
				{
					
				}
			
				GUILayout.EndHorizontal();
			
			GUILayout.EndArea();
		//End Accusation
			
		GUILayout.EndVertical ();
			
		}
	}
	
	Transform searchTarget (string _transformName, string _transformPoint)
	{
		Object [] t = FindObjectsOfType (typeof(Transform));
		foreach (Transform trans in t) 
		{
			if (trans.name == _transformName) 
			{
				if (trans.GetChildCount () > 0) 
				{
					Component[] childs = trans.GetComponentsInChildren (typeof(Transform));
					foreach (Transform child in childs) 
					{
						if (child.name == _transformPoint) 
						{
							return child;
						}
					}
				} else {
					return trans;
				}
			}
		}
		return UnknownMesh;
	}

	public void show ()
	{
		hideWindow = false;
	}

	public void hide ()
	{
		hideWindow = true;
	}

}
