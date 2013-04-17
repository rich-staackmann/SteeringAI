using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () 
	{
		
		
			// Make a background box
			GUI.Box(new Rect(10,10,100,240), "Menu");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), "Seek")) 
			{
				Application.LoadLevel(0);
			}
			//makes the second button, which loads level 2
			if(GUI.Button(new Rect(20,70,80,20), "Flee")) 
			{
				Application.LoadLevel(1);
			}

			// Make the third button. 
			if(GUI.Button(new Rect(20,100,80,20), "Arrive")) 
			{
				Application.LoadLevel(2);
			}
			if(GUI.Button(new Rect(20,130,80,20), "Pursue")) 
			{
				Application.LoadLevel(3);
			}
			if(GUI.Button(new Rect(20,160,80,20), "Wander")) 
			{
				Application.LoadLevel(4);
			}
			if(GUI.Button(new Rect(20,190,80,20), "Hide")) 
			{
				Application.LoadLevel(5);
			}
		
	}
}
