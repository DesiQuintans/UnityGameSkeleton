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
	[Tooltip("Remove an element of a PlayMaker Array List Proxy component")]
	public class ArrayListRemove : ArrayListActions
	{
		
		[ActionSection("Set up")]

		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)")]
		[UIHint(UIHint.FsmString)]
		public FsmString reference;
		
		[Tooltip("Event sent if this arraList does not contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent notFoundEvent;
		
		[ActionSection("Data")]
		[Tooltip("The type of Variable to remove. Fill the appropriate data type in the 'Data' section below")]
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
			notFoundEvent = null;
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
				DoRemoveFromArrayList();
			
			Finish();
		}
		
		
		public void DoRemoveFromArrayList()
		{
			if (! isProxyValid() ) 
				return;
			
			bool success = false;
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					success = proxy.Remove(setBoolData.Value,"bool");
					break;
				case (FsmVariableEnum.FsmColor):
					success = proxy.Remove(setColorData.Value,"color");
					break;
				case (FsmVariableEnum.FsmFloat):
					success = proxy.Remove(setFloatData.Value,"float");
					break;
				case (FsmVariableEnum.FsmGameObject	):
					success = proxy.Remove(setGameObjectData.Value,"gameObject");
					break;
				case (FsmVariableEnum.FsmInt):
					success = proxy.Remove(setIntData.Value,"int");
					break;
				case (FsmVariableEnum.FsmMaterial):
					success = proxy.Remove(setMaterialData.Value,"material");
					break;
				case (FsmVariableEnum.FsmObject):
					success = proxy.Remove(setObjectData.Value,"object");
					break;
				case (FsmVariableEnum.FsmQuaternion):
					success = proxy.Remove(setQuaternionData.Value,"quaternion");
					break;
				case (FsmVariableEnum.FsmRect):
					proxy.Remove(setRectData.Value,"rect");
					break;
				case (FsmVariableEnum.FsmString):
					success = proxy.Remove(setStringData.Value,"string");
					break;
				case (FsmVariableEnum.FsmTexture):
					proxy.Remove(setTextureData.Value,"texture");
					break;
				case (FsmVariableEnum.FsmVector3):
					success = proxy.Remove(setVector3Data.Value,"vector3");
					break;
				default:
					//ERROR
					break;
				
			}
			
			if (!success){
				Fsm.Event(notFoundEvent);
			}
		}
		
		
	}
}