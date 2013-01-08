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
	[Tooltip("Gets an item from a PlayMaker ArrayList Proxy component")]
	public class ArrayListGet : ArrayListActions
	{
		[ActionSection("Set up")]
		
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;
	
		[UIHint(UIHint.FsmInt)]
		[Tooltip("The index to retrieve the item from")]
		public FsmInt atIndex;
		
		
		[UIHint(UIHint.FsmEvent)]
		[Tooltip("The event to trigger if the action fails ( likely and index is out of range exception)")]
		public FsmEvent failureEvent;
		

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
			atIndex = null;
			gameObject = null;
			
			failureEvent = null;
			
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
			if ( SetUpArrayListProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				GetItemAtIndex();

			Finish();
		}
		
		
		
		public void GetItemAtIndex(){
			
			if (! isProxyValid())
				return;
		
			System.Type valueType = null;
			object element = null;
			
			try{
				valueType = proxy.arrayList[atIndex.Value].GetType();
				element = proxy.arrayList[atIndex.Value];
			}catch(System.Exception e){
				Debug.Log(e.Message);
				Fsm.Event(failureEvent);
				return;
			}
			
			if (valueType == typeof(bool) ){
					getBoolData.Value = (bool)element;
			}else if(valueType == typeof(Color) ){
					getColorData.Value = (Color)element;
			}else if(valueType == typeof(float) ){
				getFloatData.Value = (float)element;
			}else if(valueType == typeof(GameObject) ){	
					getGameObjectData.Value = (GameObject)element;
			}else if(valueType == typeof(int) ){
					getIntData.Value = (int)element;
			}else if(valueType == typeof(Material) ){
				 	getMaterialData.Value = (Material)element;
			}else if(valueType == typeof(ProceduralMaterial) ){
				 	getMaterialData.Value = (ProceduralMaterial)element;
			}else if(valueType == typeof(Object) ){
					getObjectData.Value = (Object)element;
			}else if(valueType == typeof(Quaternion) ){
					getQuaternionData.Value = (Quaternion)element;
			}else if(valueType == typeof(Rect) ){
					getRectData.Value = (Rect)element;
			}else if(valueType == typeof(string) ){
					getStringData.Value = (string)element;
			}else if(valueType == typeof(Texture2D) ){
					getTextureData.Value = (Texture2D)element;
			}else if(valueType == typeof(Vector3) ){
					getVector3Data.Value = (Vector3)element;
			}else{
				//  don't know, should I put in FsmObject?	
			}

		}
	}
}