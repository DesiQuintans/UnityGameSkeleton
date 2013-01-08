using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour
{
	
	void Update () {
		if (Input.anyKey)
		{
			if (Input.GetKeyDown (KeyCode.End))
			{
				Screen.lockCursor = !Screen.lockCursor;
			}
		}
	}
	
}
