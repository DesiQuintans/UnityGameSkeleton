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
	[Tooltip("Return the Last index occurence of an item from a PlayMaker Array List Proxy component. Can search within a range")]
	public class ArrayListLastIndexOf : ArrayListActions
	{
		
		[ActionSection("Set up")]
	
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)")]
		[UIHint(UIHint.FsmString)]
		public FsmString reference;
		
		[RequiredField]
		[Tooltip("The index of the last item described below")]
		[UIHint(UIHint.Variable)]
		public FsmInt lastIndexOf;
		
		[Tooltip("Optional start index to search from: set to 0 to ignore")]
		[UIHint(UIHint.FsmInt)]
		public FsmInt startIndex;
		
		[Tooltip("Optional amount of elements to search within: set to 0 to ignore")]
		[UIHint(UIHint.FsmInt)]
		public FsmInt count;
		
		[Tooltip("Event sent if this arraList contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent itemFound;	

		[Tooltip("Event sent if this arraList does not contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent itemNotFound;
		
		[Tooltip("The type of Variable to get the index of. Fill the appropriate data type in the 'Data' section below")]
		public FsmVariableEnum fsmVariableType;
		
		[ActionSection("Data")]
		
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
			startIndex = null;
			count = null;
			lastIndexOf = null;
			itemFound = null;
			itemNotFound = null;
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
				DoArrayListLastIndex();
			
			Finish();
		}
		
		
		
		public void DoArrayListLastIndex()
		{
			if (! isProxyValid() ) 
				return;
			
			object item = null;
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					item = setBoolData.Value;
					break;
				case (FsmVariableEnum.FsmColor):
					item = setColorData.Value;
					break;
				case (FsmVariableEnum.FsmFloat):
					item = setFloatData.Value;
					break;
				case (FsmVariableEnum.FsmGameObject	):
					item = setGameObjectData.Value;
					break;
				case (FsmVariableEnum.FsmInt):
					item = setIntData.Value;
					break;
				case (FsmVariableEnum.FsmMaterial):
					item = setMaterialData.Value;
					break;
				case (FsmVariableEnum.FsmObject):
					item = setObjectData.Value;
					break;
				case (FsmVariableEnum.FsmQuaternion):
					item = setQuaternionData.Value;
					break;
				case (FsmVariableEnum.FsmRect):
					item = setRectData.Value;
					break;
				case (FsmVariableEnum.FsmString):
					item = setStringData.Value;
					break;
				case (FsmVariableEnum.FsmTexture):
					item = setTextureData.Value;
					break;
				case (FsmVariableEnum.FsmVector3):
					item = setVector3Data.Value;
					break;
				default:
					//ERROR
					break;
				
			}
			
			int index = -1;
			
			if (startIndex.Value == 0 && count.Value == 0){
				
				index = proxy.arrayList.LastIndexOf(item);
	
			}else if (count.Value == 0 ){
				if (startIndex.Value<0 || startIndex.Value>=proxy.arrayList.Count){
					Debug.LogError("start index out of range");
					return;
				}
					index = proxy.arrayList.LastIndexOf(item,startIndex.Value);
				
			}else{
				if (startIndex.Value<0 || startIndex.Value>=(proxy.arrayList.Count-count.Value)){
					Debug.LogError("start index and count out of range");
					return;
				}
				index = proxy.arrayList.LastIndexOf(item,startIndex.Value,count.Value);
			}
			
			lastIndexOf.Value = index;
			if (index==-1){
				Fsm.Event(itemNotFound);
			}else{
				Fsm.Event(itemFound);
			}
			
		}
	}
}