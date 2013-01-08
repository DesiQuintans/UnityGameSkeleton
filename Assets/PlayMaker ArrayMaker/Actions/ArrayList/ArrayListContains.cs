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
	[Tooltip("Check if an item is contains in a particula PlayMaker ArrayList Proxy component")]
	public class ArrayListContains : ArrayListActions
	{
		
		[ActionSection("Set up")]

		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)")]
		[UIHint(UIHint.FsmString)]
		public FsmString reference;
		
		[Tooltip("Store in a bool wether it contains or not that element (described below)")]
		[UIHint(UIHint.Variable)]
		public FsmBool isContained;	
		
		[Tooltip("Event sent if this arraList contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent isContainedEvent;	

		[Tooltip("Event sent if this arraList does not contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent isNotContainedEvent;
		
		
		[Tooltip("The type of Variable to check. Fill the appropriate data type in the 'Data' section below")]
		public FsmVariableEnum fsmVariableType;
		
		[ActionSection("Data")]
		
		public FsmInt containsIntData;
		public FsmFloat containsFloatData;
		public FsmString containsStringData;
		public FsmBool containsBoolData;
		public FsmVector3 containsVector3Data;
		public FsmGameObject containsGameObjectData;
		public FsmRect containsRectData;
		public FsmQuaternion containsQuaternionData;
		public FsmColor containsColorData;
		public FsmMaterial containsMaterialData;
		public FsmTexture containsTextureData;
		
		public FsmObject containsObjectData;
		
		
		public override void Reset()
		{
			gameObject = null;
			reference = null;
			containsBoolData = null;
			containsIntData = null;
			containsFloatData = null;
			containsVector3Data = null;
			containsStringData = null;
			containsGameObjectData = null;
			
			isContained = null;
			isContainedEvent = null;
			isNotContainedEvent = null;
		}
		
		
		public override void OnEnter()
		{
			if ( SetUpArrayListProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				doesArrayListContains();
			
			
			Finish();
		}
		
		
		public void doesArrayListContains()
		{

			if (! isProxyValid() ) 
				return;
			
			bool elementContained = false;
	
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					elementContained = proxy.arrayList.Contains(containsBoolData.Value);
					break;
				case (FsmVariableEnum.FsmColor):
					elementContained = proxy.arrayList.Contains(containsColorData.Value);
					break;
				case (FsmVariableEnum.FsmFloat):
					elementContained = proxy.arrayList.Contains(containsFloatData.Value);
					break;
				case (FsmVariableEnum.FsmGameObject	):
					elementContained = proxy.arrayList.Contains(containsGameObjectData.Value);
					break;
				case (FsmVariableEnum.FsmInt):
					elementContained = proxy.arrayList.Contains(containsIntData.Value);
					break;
				case (FsmVariableEnum.FsmMaterial):
					elementContained = proxy.arrayList.Contains(containsMaterialData.Value);
					break;
				case (FsmVariableEnum.FsmObject):
					elementContained = proxy.arrayList.Contains(containsObjectData.Value);
					break;
				case (FsmVariableEnum.FsmQuaternion):
					elementContained = proxy.arrayList.Contains(containsQuaternionData.Value);
					break;
				case (FsmVariableEnum.FsmRect):
					elementContained = proxy.arrayList.Contains(containsRectData.Value);
					break;
				case (FsmVariableEnum.FsmString):
					elementContained = proxy.arrayList.Contains(containsStringData.Value);
					break;
				case (FsmVariableEnum.FsmTexture):
					elementContained = proxy.arrayList.Contains(containsTextureData.Value);
					break;
				case (FsmVariableEnum.FsmVector3):
					elementContained = proxy.arrayList.Contains(containsVector3Data.Value);
					break;
				default:
					//ERROR
					break;
			}
			
			UnityEngine.Debug.Log(elementContained.ToString());
			isContained.Value = elementContained;
			if(elementContained){
				Fsm.Event(isContainedEvent);
			}else{
				Fsm.Event(isNotContainedEvent);
			}
			
		}
		
		
	}
}