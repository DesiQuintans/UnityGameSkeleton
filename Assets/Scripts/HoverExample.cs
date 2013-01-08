using UnityEngine;
using System.Collections;

public class HoverExample : MonoBehaviour {
	
    void FixedUpdate()
    {
            Vector3 pos = new Vector3(0, (Mathf.Sin(Time.time) * Time.deltaTime)/4, 0);
            gameObject.transform.Translate (pos);
        
    }
}
