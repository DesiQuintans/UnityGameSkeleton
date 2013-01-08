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
	[ActionCategory("ArrayMaker/HashTable")]
	[Tooltip("Gets an item from a PlayMaker HashTable Proxy component")]
	public class HashTableGet : HashTableActions
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
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger when key is found")]
		public FsmEvent KeyFoundEvent;
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger when key is not found")]
		public FsmEvent KeyNotFoundEvent;
		
		[ActionSection("Data Storage")]
		[UIHint(UIHint.Variable)]
		public FsmBool getBoolData;
		[UIHint(UIHint.Variable)]
		public FsmInt getIntData;
		[UIHint(UIHint.Variable)]
		public FsmFloat getFloatData;
		[UIHint(UIHint.Variable)]
		public FsmVector3 getVector3Data;
		[UIHint(UIHint.Variable)]
		public FsmString getStringData;
		[UIHint(UIHint.Variable)]
		public FsmGameObject getGameObjectData;
		[UIHint(UIHint.Variable)]
		public FsmRect getRectData;
		[UIHint(UIHint.Variable)]
		public FsmQuaternion getQuaternionData;
		[UIHint(UIHint.Variable)]
		public FsmMaterial getMaterialData;
		[UIHint(UIHint.Variable)]
		public FsmTexture getTextureData;
		[UIHint(UIHint.Variable)]
		public FsmColor getColorData;
		[UIHint(UIHint.Variable)]
		public FsmObject getObjectData;

		public override void Reset()
		{
			
			gameObject = null;
			key = null;
			
			KeyFoundEvent = null;
			KeyNotFoundEvent = null;
			
			getBoolData = null;
			getIntData = null;
			getFloatData = null;
			getVector3Data = null;
			getStringData = null;
			getGameObjectData = null;
			getRectData = null;
			getQuaternionData = null;
			getMaterialData = null;
			getTextureData = null;
			getColorData = null;
			getObjectData = null;
			
			
		}

		public override void OnEnter()
		{
			if ( SetUpHashTableProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				Get();

			Finish();
		}
		
		public void Get(){
			
			if (! isProxyValid())
				return;
			
			if (!proxy.hashTable.ContainsKey(key.Value)){
				Fsm.Event(KeyNotFoundEvent);
				return;
			}
			
			System.Type valueType = proxy.hashTable[key.Value].GetType();

			if (valueType == typeof(bool) ){
					getBoolData.Value = (bool)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Color) ){
					getColorData.Value = (Color)proxy.hashTable[key.Value];
			}else if(valueType == typeof(float) ){
				getFloatData.Value = (float)proxy.hashTable[key.Value];
			}else if(valueType == typeof(GameObject) ){
					getGameObjectData.Value = (GameObject)proxy.hashTable[key.Value];
			}else if(valueType == typeof(int) ){
					getIntData.Value = (int)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Material) ){
				 	getMaterialData.Value = (Material)proxy.hashTable[key.Value];
			}else if(valueType == typeof(ProceduralMaterial) ){
				 	getMaterialData.Value = (ProceduralMaterial)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Object) ){
					getObjectData.Value = (Object)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Quaternion) ){
					getQuaternionData.Value = (Quaternion)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Rect) ){
					getRectData.Value = (Rect)proxy.hashTable[key.Value];
			}else if(valueType == typeof(string) ){
					getStringData.Value = (string)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Texture2D) ){
					getTextureData.Value = (Texture2D)proxy.hashTable[key.Value];
			}else if(valueType == typeof(Vector3) ){
					getVector3Data.Value = (Vector3)proxy.hashTable[key.Value];
			}else{
				// don't know, should I put it in FsmObject?
			}
			
			Fsm.Event(KeyFoundEvent);

		}
	}
}