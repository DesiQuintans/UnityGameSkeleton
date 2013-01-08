//	(c) Jean Fabre, 2011-2012 All rights reserved.
//	http://www.fabrejean.net
//  contact: http://www.fabrejean.net/contact.htm
//
// Version Alpha 0.9

// INSTRUCTIONS
// Drop a PlayMakerHashTableProxy script onto a GameObject, and define a unique name for reference if several PlayMakerHashTableProxy coexists on that GameObject.
// In this Action interface, link that GameObject in "hashTableObject" and input the reference name if defined. 
// Note: You can directly reference that GameObject or store it in an Fsm variable or global Fsm variable

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ArrayMaker/HashTable")]
	[Tooltip("Check if a value exists in a PlayMaker HashTable Proxy component (PlayMakerHashTablePRoxy)")]
	public class HashTableContainsValue : HashTableActions
	{
		
		[ActionSection("Set up")]

		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker HashTable Proxy component")]
		[CheckForComponent(typeof(PlayMakerHashTableProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker HashTable Proxy component (necessary if several component coexists on the same GameObject)")]
		public FsmString reference;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result of the test")]
		public FsmBool containsValue;
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger when value is found")]
		public FsmEvent valueFoundEvent;
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger when value is not found")]
		public FsmEvent valueNotFoundEvent;
		
		[Tooltip("The type of Variable to check for. Fill the appropriate data type in the 'Data' section below")]
		public FsmVariableEnum fsmVariableType;
		
		[ActionSection("Data")]
		
		public FsmInt checkIntData;
		public FsmFloat checkFloatData;
		public FsmString checkStringData;
		public FsmBool checkBoolData;
		public FsmVector3 checkVector3Data;
		public FsmGameObject checkGameObjectData;
		public FsmRect checkRectData;
		public FsmQuaternion checkQuaternionData;
		public FsmColor checkColorData;
		public FsmMaterial checkMaterialData;
		public FsmTexture checkTextureData;
		public FsmObject checkObjectData;
		
		
		public override void Reset()
		{
			gameObject = null;
			reference = null;
			containsValue = null;
			checkBoolData = null;
			checkIntData = null;
			checkFloatData = null;
			checkVector3Data = null;
			checkStringData = null;
			checkGameObjectData = null;
		}
		
		
		public override void OnEnter()
		{
			if (SetUpHashTableProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value))
				doContainsValue();
			
			Finish();
		}
		
		
		public void doContainsValue()
		{

			if (!isProxyValid()) 
				return;
			
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					containsValue.Value = proxy.hashTable.ContainsValue(checkFloatData.Value);
					break;
				case (FsmVariableEnum.FsmColor):
					containsValue.Value = proxy.hashTable.ContainsValue(checkColorData.Value);
					break;
				case (FsmVariableEnum.FsmFloat):
					containsValue.Value = proxy.hashTable.ContainsValue(checkFloatData.Value);
					break;
				case (FsmVariableEnum.FsmGameObject	):
					containsValue.Value = proxy.hashTable.ContainsValue(checkGameObjectData.Value);
					break;
				case (FsmVariableEnum.FsmInt):
					containsValue.Value = proxy.hashTable.ContainsValue(checkIntData.Value);
					break;
				case (FsmVariableEnum.FsmMaterial):
					containsValue.Value = proxy.hashTable.ContainsValue(checkMaterialData.Value);
					break;
				case (FsmVariableEnum.FsmObject):
					containsValue.Value = proxy.hashTable.ContainsValue(checkObjectData.Value);
					break;
				case (FsmVariableEnum.FsmQuaternion):
					containsValue.Value = proxy.hashTable.ContainsValue(checkQuaternionData.Value);
					break;
				case (FsmVariableEnum.FsmRect):
					containsValue.Value = proxy.hashTable.ContainsValue(checkRectData.Value);
					break;
				case (FsmVariableEnum.FsmString):
					containsValue.Value = proxy.hashTable.ContainsValue(checkStringData.Value);
					break;
				case (FsmVariableEnum.FsmTexture):
					containsValue.Value = proxy.hashTable.ContainsValue(checkTextureData.Value);
					break;
				case (FsmVariableEnum.FsmVector3):
					containsValue.Value = proxy.hashTable.ContainsValue(checkVector3Data.Value);
					break;
				default:
					//ERROR
					break;
				
			}
			
			if (containsValue.Value){
				Fsm.Event(valueFoundEvent);
			}else{
				Fsm.Event(valueNotFoundEvent);
			}
			
			
		}// doContainsValue	
	}
}