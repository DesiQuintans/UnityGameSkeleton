using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


public class GameInspectorManager : MonoBehaviour
{
	public string windowTitle = "Inspector";
	public int nameWidth = 64;
	public bool followMouse = true;
	public GUISkin skin;
	public Rect rect = new Rect (10, 10, 200, 120);

	private GameInspector hot = null;

	public void Show (GameInspector node)
	{
		hot = node;
	}

	public void Hide (GameInspector node)
	{
		if (node == hot)
			hot = null;
	}

	void OnGUI ()
	{
		if (hot == null)
			return;
		if (skin != null)
			GUI.skin = skin;
		if(followMouse) {
			//make the inspector follow the mouse.
			rect.x = (int)Input.mousePosition.x;
			rect.y = (int)Screen.height - Input.mousePosition.y;
			//try and keep the inspector window visible regardless of mouse position.
			rect.x -= (Input.mousePosition.x > Screen.width / 2)?rect.width + 5:-5;
			rect.y -= (Input.mousePosition.y < Screen.height / 2)?rect.height + 5:-5;
		}
		//This draws the inspector window.
		GUILayout.BeginArea (rect, windowTitle, "box");
		GUILayout.Space (16);
		foreach (var d in hot.descriptors) {
			GUILayout.BeginHorizontal ();
			GUILayout.Label (d.attr.niceName, GUILayout.Width (nameWidth));
			GUILayout.Label (d.Value.ToString ());
			GUILayout.EndHorizontal ();
		}
		GUILayout.EndArea ();
	}
	
	
}
