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
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ArrayMaker/ArrayList")]
	[Tooltip("Add several items to a PlayMaker Array List Proxy component")]
	public class ArrayListAddRange : ArrayListActions
	{
		
		[ActionSection("Set up")]

		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)")]
		[UIHint(UIHint.FsmString)]
		public FsmString reference;
		
		[Tooltip("The type of Variable to add. Fill the appropriate data type in the 'Data' section below")]
		public FsmVariableEnum fsmVariableType;
		
		[ActionSection("Data")]
		
		public FsmInt[] setIntData;
		public FsmFloat[] setFloatData;
		public FsmString[] setStringData;
		public FsmBool[] setBoolData;
		public FsmVector3[] setVector3Data;
		public FsmGameObject[] setGameObjectData;
		public FsmRect[] setRectData;
		public FsmQuaternion[] setQuaternionData;
		public FsmColor[] setColorData;
		public FsmMaterial[] setMaterialData;
		public FsmTexture[] setTextureData;
		
		public FsmObject[] setObjectData;
		
		
		public override void Reset()
		{
			gameObject = null;
			reference = null;
			setBoolData = null;
			setIntData = null;
			setFloatData = null;
			setVector3Data = null;
			setStringData = null;
			setGameObjectData = null;
		}
		
		
		public override void OnEnter()
		{
			if ( SetUpArrayListProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				DoArrayListAddRange();
			
			Finish();
		}
		
		
		public void DoArrayListAddRange()
		{
			if (! isProxyValid() ) 
				return;
			
			// TOFIX: ouch, is there not a better way to get values from a fsmXXX[]? surely, c# can allow for more clever coding... only my knoweldge of it is lacking.
			ArrayList coll = new ArrayList();
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):

					foreach(FsmBool fsmxxx in setBoolData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"bool");
					break;
				
				case (FsmVariableEnum.FsmColor):
					
					foreach(FsmColor fsmxxx in setColorData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"color");
					break;
				case (FsmVariableEnum.FsmFloat):
					
					foreach(FsmFloat fsmxxx in setFloatData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"float");
					break;
				case (FsmVariableEnum.FsmGameObject	):
					
					foreach(FsmGameObject fsmxxx in setGameObjectData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"gameObject");
					break;
				case (FsmVariableEnum.FsmInt):
					
					foreach(FsmInt fsmxxx in setIntData) coll.Add(fsmxxx.Value);
					proxy.AddRange(coll,"int");
					break;
				case (FsmVariableEnum.FsmMaterial):
					
					foreach(FsmMaterial fsmxxx in setMaterialData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"material");
					break;
				case (FsmVariableEnum.FsmObject):
					
					foreach(FsmObject fsmxxx in setObjectData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"object");
					break;
				case (FsmVariableEnum.FsmQuaternion):
					
					foreach(FsmQuaternion fsmxxx in setQuaternionData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"quaternion");
					break;
				case (FsmVariableEnum.FsmRect):
					
					foreach(FsmRect fsmxxx in setRectData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"rect");
					break;
				case (FsmVariableEnum.FsmString):
					
					foreach(FsmString fsmxxx in setStringData) coll.Add(fsmxxx.Value);
	
					proxy.AddRange(coll,"string");
					break;
				case (FsmVariableEnum.FsmTexture):
					
					foreach(FsmTexture fsmxxx in setTextureData) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"texture");
					break;
				case (FsmVariableEnum.FsmVector3):
					
					foreach(FsmVector3 fsmxxx in setVector3Data) coll.Add(fsmxxx.Value);
				
					proxy.AddRange(coll,"vector3");
					break;
					
				default:
					//ERROR
					break;
				
			}
		}
		
		
	}
}