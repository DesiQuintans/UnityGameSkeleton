using UnityEngine;
using System.Collections;

/*
	Autoparent
	By Desi Quintans (CowfaceGames.com, 16 Aug 2012)
	
	Drag this onto a GameObject and it will be parented to an Inspector-declared GameObject on runtime.
	Useful for prefabs that will be instantiated en masse.
*/

public class AutoParent : MonoBehaviour
{
	// Inspector-accessible variables.
	public GameObject newParent;

	void Start ()
	{
		transform.parent = newParent.transform;
	}
}
