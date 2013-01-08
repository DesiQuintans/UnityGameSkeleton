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
	[Tooltip("Set an key/value pair to a PlayMaker HashTable Proxy component (PlayMakerHashTableProxy)")]
	public class HashTableSet : HashTableActions
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
		[Tooltip("The Key value for that hash set")]
		public FsmString key;
	
		[UIHint(UIHint.FsmBool)]
		[Tooltip("Set Value if key exists already")]
		public FsmBool setValueIfKeyExists;	
		
		[Tooltip("The type of Variable to set. Fill the appropriate data type in the 'Data' section below")]
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
			key = null;
			setValueIfKeyExists = null;
			setBoolData = null;
			setIntData = null;
			setFloatData = null;
			setVector3Data = null;
			setStringData = null;
			setGameObjectData = null;
		}
		
		
		public override void OnEnter()
		{
			if (SetUpHashTableProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value))
			{
				//if (proxy.hashTable.ContainsKey(key.Value))
				//{
				//	if (setValueIfKeyExists.Value)
						SetHashTable();
				//}else{
				//	AddToHashTable();
				//}  
			}else{
				Debug.Log("...");
			}
			
			Finish();
		}
		
		
		public void AddToHashTable()
		{

			if (!isProxyValid()) 
				return;
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					proxy.hashTable.Add(key.Value,setFloatData.Value);
					break;
				case (FsmVariableEnum.FsmColor):
					proxy.hashTable.Add(key.Value,setColorData.Value);
					break;
				case (FsmVariableEnum.FsmFloat):
					proxy.hashTable.Add(key.Value,setFloatData.Value);
					break;
				case (FsmVariableEnum.FsmGameObject	):
					proxy.hashTable.Add(key.Value,setGameObjectData.Value);
					break;
				case (FsmVariableEnum.FsmInt):
					proxy.hashTable.Add(key.Value,setIntData.Value);
					break;
				case (FsmVariableEnum.FsmMaterial):
					proxy.hashTable.Add(key.Value,setMaterialData.Value);
					break;
				case (FsmVariableEnum.FsmObject):
					proxy.hashTable.Add(key.Value,setObjectData.Value);
					break;
				case (FsmVariableEnum.FsmQuaternion):
					proxy.hashTable.Add(key.Value,setQuaternionData.Value);
					break;
				case (FsmVariableEnum.FsmRect):
					proxy.hashTable.Add(key.Value,setRectData.Value);
					break;
				case (FsmVariableEnum.FsmString):
					proxy.hashTable.Add(key.Value,setStringData.Value);
					break;
				case (FsmVariableEnum.FsmTexture):
					proxy.hashTable.Add(key.Value,setTextureData.Value);
					break;
				case (FsmVariableEnum.FsmVector3):
					proxy.hashTable.Add(key.Value,setVector3Data.Value);
					break;
				default:
					//ERROR
					break;
				
			}
			
		}

		public void SetHashTable()
		{

			if (!isProxyValid()) 
				return;
			
			switch (fsmVariableType){
				case (FsmVariableEnum.FsmBool):
					proxy.hashTable[key.Value] = setFloatData.Value;
					break;
				case (FsmVariableEnum.FsmColor):
					proxy.hashTable[key.Value] = setColorData.Value;
					break;
				case (FsmVariableEnum.FsmFloat):
					proxy.hashTable[key.Value] = setFloatData.Value;
					break;
				case (FsmVariableEnum.FsmGameObject	):
					proxy.hashTable[key.Value] = setGameObjectData.Value;
					break;
				case (FsmVariableEnum.FsmInt):
					proxy.hashTable[key.Value] = setIntData.Value;
					break;
				case (FsmVariableEnum.FsmMaterial):
					proxy.hashTable[key.Value] = setMaterialData.Value;
					break;
				case (FsmVariableEnum.FsmObject):
					proxy.hashTable[key.Value] = setObjectData.Value;
					break;
				case (FsmVariableEnum.FsmQuaternion):
					proxy.hashTable[key.Value] = setQuaternionData.Value;
					break;
				case (FsmVariableEnum.FsmRect):
					proxy.hashTable[key.Value] = setRectData.Value;
					break;
				case (FsmVariableEnum.FsmString):
					proxy.hashTable[key.Value] = setStringData.Value;
					break;
				case (FsmVariableEnum.FsmTexture):
					proxy.hashTable[key.Value] = setTextureData.Value;
					break;
				case (FsmVariableEnum.FsmVector3):
					proxy.hashTable[key.Value] = setVector3Data.Value;
					break;
				default:
					//ERROR
					break;
				
			}
			
		}
		
		
	}
}