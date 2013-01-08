using UnityEngine;
using System.Collections;

public class AboutUI : MonoBehaviour {
	
	public GUISkin customSkin;
	
	void OnGUI () {
		
		GUI.skin = customSkin;
		
		GUILayout.BeginArea (new Rect (Screen.width/2 - Screen.width/8, Screen.height/2, Screen.width/4, Screen.height/3));
		
			GUILayout.Label ("Game Skeleton\nMade in 48 hours for Ludum Dare 25.\n\nDesi Quintans, December 2012.\nCowfaceGames.com");
		
			if (GUILayout.Button ("Back to menu")) {
				Application.LoadLevel ("Main Menu");
			}
			
		GUILayout.EndArea ();
		
	}
}