using UnityEngine;
using System.Collections;

public class GameInspectorExampleCS : MonoBehaviour {
	
	[Inspectable("Target", 0)]
	public string target = "Not me.";
	[Inspectable("Health", -1)]
	public float health = 99.9f;
	
	void Update() {
		health -= Random.value * Time.deltaTime;	
	}
}
