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
	[Tooltip("Add an item to a PlayMaker Array List Proxy component")]
	public class ArrayListAdd : ArrayListActions
	{
		
		[ActionSection("Set up")]
		
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)")]
		[UIHint(UIHint.FsmString)]
		public FsmString reference;
		
		[ActionSection("Data")]
		[Tooltip("The type of Variable to add. Fill the appropriate data type in the 'Data' section below")]
		public FsmVariableEnum fsmVariableType;

		public FsmInt setIntData;
		public FsmFloat setFloatData;
		public FsmString setStringData;
		public FsmBool setBoolData;
		public FsmVector3 setVector3Data;
		public FsmGameObject setGameObjectData;
		public FsmRect setRectData;
		public FsmQuaternion setQuaternionData;
		public FsmColor setColorData;
		public FsmMaterial setMaterialData;
		public FsmTexture setTextureData;
		
		public FsmObject setObjectData;
		
		
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
				AddToArrayList();
			
			Finish();
		}
		
		
		public void AddToArrayList()
		{
			if (! isProxyValid() ) 
				return;
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					proxy.Add(setBoolData.Value,"bool");
					break;
				case (FsmVariableEnum.FsmColor):
					proxy.Add(setColorData.Value,"color");
					break;
				case (FsmVariableEnum.FsmFloat):
					proxy.Add(setFloatData.Value,"float");
					break;
				case (FsmVariableEnum.FsmGameObject	):
					proxy.Add(setGameObjectData.Value,"gameObject");
					break;
				case (FsmVariableEnum.FsmInt):
					proxy.Add(setIntData.Value,"int");
					break;
				case (FsmVariableEnum.FsmMaterial):
					proxy.Add(setMaterialData.Value,"material");
					break;
				case (FsmVariableEnum.FsmObject):
					proxy.Add(setObjectData.Value,"object");
					break;
				case (FsmVariableEnum.FsmQuaternion):
					proxy.Add(setQuaternionData.Value,"quaternion");
					break;
				case (FsmVariableEnum.FsmRect):
					proxy.Add(setRectData.Value,"rect");
					break;
				case (FsmVariableEnum.FsmString):
					proxy.Add(setStringData.Value,"string");
					break;
				case (FsmVariableEnum.FsmTexture):
					proxy.Add(setTextureData.Value,"texture");
					break;
				case (FsmVariableEnum.FsmVector3):
					proxy.Add(setVector3Data.Value,"vector3");
					break;
				default:
					//ERROR
					break;
				
			}
		}
		
		
	}
}