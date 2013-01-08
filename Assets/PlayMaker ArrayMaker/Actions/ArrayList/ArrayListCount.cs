//	(c) Jean Fabre, 2011-2012 All rights reserved.
//	http://www.fabrejean.net
//  contact: http://www.fabrejean.net/contact.htm
//
// Version Alpha 0.9

// INSTRUCTIONS
// Drop a PlayMakerArrayList script onto a GameObject, and define a unique name for reference if several PlayMakerArrayList coexists on that GameObject.
// In this Action interface, link that GameObject in "arrayListObject" and input the reference name if defined. 
// Note: You can directly reference that GameObject or store it in an Fsm variable or global Fsm variable

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ArrayMaker/ArrayList")]
	[Tooltip("Count items from a PlayMaker ArrayList Proxy component")]
	public class ArrayListCount : ArrayListActions
	{
		[ActionSection("Set up")]
		
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;
		
		
		[ActionSection("Storage")]
		[UIHint(UIHint.FsmInt)]
		[Tooltip("Store the count value")]
		public FsmInt count;
		
		
		public override void Reset()
		{
			gameObject = null;
			reference = null;
			count = null;
		}

		
		public override void OnEnter()
		{
			if ( SetUpArrayListProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				getArrayListCount();
			
			Finish();
		}

		
		public void getArrayListCount()
		{
			if (! isProxyValid()) 
				return;
			
			int c = proxy.arrayList.Count;
			count.Value = c;
		}
	}
}