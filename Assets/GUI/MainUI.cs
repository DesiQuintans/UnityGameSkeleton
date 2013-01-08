using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {
	
	public GUISkin customSkin;
	
	void OnGUI () {
		
		GUI.skin = customSkin;
		
		GUILayout.BeginArea (new Rect (Screen.width/2 - Screen.width/8, Screen.height/2, Screen.width/4, Screen.height/3));
		
			GUILayout.Label ("Game Skeleton");
		
			if (GUILayout.Button ("Play Game")) {
				Application.LoadLevel ("Game");
			}
			
			if (GUILayout.Button ("About")) {
				Application.LoadLevel ("About");
			}
			
		GUILayout.EndArea ();
		
	}
	
}
