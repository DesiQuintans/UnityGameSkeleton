//	(c) Jean Fabre, 2011-2012 All rights reserved.
//	http://www.fabrejean.net
//  contact: http://www.fabrejean.net/contact.htm
//
// Version Alpha 0.9

// INSTRUCTIONS
// Drop a PlayMakerHashTable script onto a GameObject, and define a unique name for reference if several PlayMakerHashTableProxy coexists on that GameObject.
// In this Action interface, link that GameObject in "hashTableObject" and input the reference name if defined. 
// Note: You can directly reference that GameObject or store it in an Fsm variable or global Fsm variable

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ArrayMaker/HashTable")]
	[Tooltip("Check if a key exists in a PlayMaker HashTable Proxy component (PlayMakerHashTablePRoxy)")]
	public class HashTableContains : HashTableActions
	{
		
		[ActionSection("Set up")]

		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker HashTable Proxy component")]
		[CheckForComponent(typeof(PlayMakerHashTableProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker HashTable Proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;
		
		[RequiredField]
		[UIHint(UIHint.FsmString)]
		[Tooltip("The Key value to check for")]
		public FsmString key;
		
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Store the result of the test")]
		public FsmBool containsKey;	
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger when key is found")]
		public FsmEvent keyFoundEvent;
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger when key is not found")]
		public FsmEvent keyNotFoundEvent;
		
		
		
		public override void Reset()
		{
			gameObject = null;
			reference = null;
			key = null;
			containsKey = null;
			keyFoundEvent = null;
			keyNotFoundEvent = null;
		}
		
		
		
		public override void OnEnter()
		{
			if (SetUpHashTableProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value)) 
				checkIfContainsKey();
			
			Finish();
		}
		
		
		
		public void checkIfContainsKey()
		{
			
			if (!isProxyValid()) 
				return;

			containsKey.Value = proxy.hashTable.Contains(key.Value);
			if (containsKey.Value){
				Fsm.Event(keyFoundEvent);
			}else{
				Fsm.Event(keyNotFoundEvent);
			}
			
			
		}// checkIfContainsKey
		
		
	}
}