//	(c) Jean Fabre, 2011-2012 All rights reserved.
//	http://www.fabrejean.net
//  contact: http://www.fabrejean.net/contact.htm
//
// Version Alpha 0.9

// This is the arrayList abstract class in between actual actions and the CollectionsAction root for all actions related to ArrayList

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	public abstract class ArrayListActions : CollectionsActions  {
		
			internal PlayMakerArrayListProxy proxy;
		
		
			protected bool SetUpArrayListProxyPointer(GameObject aProxyGO,string nameReference){
				
				if (aProxyGO == null){
					return false;
				}
				 proxy = GetArrayListProxyPointer(aProxyGO,nameReference,false);

				return proxy!=null;
			}		

			protected bool SetUpArrayListProxyPointer(PlayMakerArrayListProxy aProxy,string nameReference){
				
				if (aProxy == null){
					return false;
				}
				 proxy = GetArrayListProxyPointer(aProxy.gameObject,nameReference,false);

				return proxy!=null;
			}

		
		
		
			public bool isProxyValid()
			{
						
				if (proxy==null){
					LogError("ArrayList proxy is null");
					return false;
				}			
				if (proxy.arrayList ==null){
					LogError("ArrayList undefined");
					return false;
				}
				
				return true;
			}// isProxyValid
		
	}
}