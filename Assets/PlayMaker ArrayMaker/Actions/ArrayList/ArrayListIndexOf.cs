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
	[Tooltip("Return the index of an item from a PlayMaker Array List Proxy component. Can search within a range")]
	public class ArrayListIndexOf : ArrayListActions
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
		[Tooltip("The index of the item described below")]
		[UIHint(UIHint.Variable)]
		public FsmInt indexOf;
		
		[Tooltip("Optional start index to search from: set to 0 to ignore")]
		[UIHint(UIHint.FsmInt)]
		public FsmInt index;
		
		[Tooltip("Optional amount of elements to search within: set to 0 to ignore")]
		[UIHint(UIHint.FsmInt)]
		public FsmInt count;
		
		[Tooltip("Optional Event sent if this arrayList contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent itemFound;	

		[Tooltip("Optional Event sent if this arrayList does not contains that element ( described below)")]
		[UIHint(UIHint.FsmEvent)]
		public FsmEvent itemNotFound;
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("Optional Event to trigger if the action fails ( likely an out of range exception when using wrong values for index and/or count)")]
		public FsmEvent failureEvent;
		
		
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
			index = null;
			count = null;
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
			if ( SetUpArrayListProxyPointer( Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				DoArrayListIndexOf();
			
			Finish();
		}
		
		
		public void DoArrayListIndexOf()
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
		
			int indexOfResult = -1;
			
			try{
				if (index == null){
					
					indexOfResult = proxy.arrayList.IndexOf(item);
		
				}else if (count==null || count.Value == 0 ){
					if (index.Value<0 || index.Value>=proxy.arrayList.Count){
						LogError("start index out of range");
						return;
					}
						indexOfResult = proxy.arrayList.IndexOf(item,index.Value);
					
				}else{
					if (index.Value<0 || index.Value>=(proxy.arrayList.Count-count.Value)){
						LogError("start index and count out of range");
						return;
					}
					indexOfResult = proxy.arrayList.IndexOf(item,index.Value,count.Value);
				}
			}catch(System.Exception e){
				Debug.LogError(e.Message);
				Fsm.Event(failureEvent);
				return;
			}
			
			
			indexOf.Value = indexOfResult;
			if (indexOfResult==-1){
				Fsm.Event(itemNotFound);
			}else{
				Fsm.Event(itemFound);
			}
			
		}
	}
}