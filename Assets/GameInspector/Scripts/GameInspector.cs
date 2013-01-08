using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class GameInspector : MonoBehaviour
{
	
	
	public List<Descriptor> descriptors = new List<Descriptor> ();
	GameInspectorManager manager;
	
	void Start ()
	{
		//NB: this will throw null reference if GameInspectorManager is not in the scene.
		manager = GameObject.Find("/GameInspectorManager").GetComponent<GameInspectorManager>();
		
		foreach (var component in gameObject.GetComponents<Component> ()) {
			var fields = component.GetType ().GetFields ();
			foreach (var info in fields) {
				var attributes = info.GetCustomAttributes (true);
				foreach (var a in attributes) {
					if (a.GetType () == typeof(InspectableAttribute)) {
						descriptors.Add (new Descriptor (component, info, a as InspectableAttribute));
					}
				}
			}
		}
		//sort the Inspectable values using the rank value.
		descriptors.Sort (delegate(Descriptor A, Descriptor B) {
			if (A.attr.rank == B.attr.rank)
				return 0;
			return A.attr.rank < B.attr.rank ? -1 : 1;
		});
		
	}
	
	//These two functions make the inspector display when the mouse is
	//over the game object.
	void OnMouseEnter() {
		manager.Show(this);
	}
	
	void OnMouseExit() {
		manager.Hide(this);
	}
	
}


public class Descriptor
{
	public Component component;
	public FieldInfo info;
	public InspectableAttribute attr;
	public Descriptor (Component component, FieldInfo info, InspectableAttribute attr)
	{
		this.component = component;
		this.info = info;
		this.attr = attr;
	}
	public object Value {
		get { return info.GetValue (component); }
		set { info.SetValue (component, value); }
	}
}




