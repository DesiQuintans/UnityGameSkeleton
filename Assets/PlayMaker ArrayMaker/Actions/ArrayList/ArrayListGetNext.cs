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
	[Tooltip("Each time this action is called it gets the next item from a PlayMaker ArrayList Proxy component. \n" +
		"This lets you quickly loop through all the children of an object to perform actions on them.\n" +
		 "NOTE: To get to specific item use ArrayListGet instead.")]
	public class ArrayListGetNext : ArrayListActions
	{
		[ActionSection("Set up")]
		
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;
	
		[Tooltip("From where to start iteration, leave to 0 to start from the beginning")]
		public FsmInt startIndex;
		
		[Tooltip("When to end iteration, leave to 0 to iterate until the end")]
		public FsmInt endIndex;
		
		[Tooltip("Event to send to get the next item.")]
		public FsmEvent loopEvent;

		[Tooltip("Event to send when there are no more items.")]
		public FsmEvent finishedEvent;
		
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
		
		
		
		// increment that index as we loop through item
		private int nextItemIndex = 0;
		
		
		public override void Reset()
		{
		
			gameObject = null;
			reference = null;
			startIndex = null;
			endIndex = null;
			
			loopEvent = null;
			finishedEvent = null;
	
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
			
			if (nextItemIndex == 0)
			{
				if ( ! SetUpArrayListProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
				{
					Fsm.Event(failureEvent);
					
					Finish();
				}
				
				if (startIndex.Value>0)
				{
					nextItemIndex = startIndex.Value;
				}
			}
			
			DoGetNextItem();
			
			Finish();
		}
		

		void DoGetNextItem()
		{

			// no more children?
			// check first to avoid errors.

			if (nextItemIndex >= proxy.arrayList.Count)
			{
				nextItemIndex = 0;
				Fsm.Event(finishedEvent);
				return;
			}

			// get next item

			GetItemAtIndex();


			// no more items?
			// check a second time to avoid process lock and possible infinite loop if the action is called again.
			// Practically, this enabled calling again this state and it will start again iterating from the first child.
			if (nextItemIndex >= proxy.arrayList.Count)
			{
				nextItemIndex = 0;
				Fsm.Event(finishedEvent);
				return;
			}
			
			if (endIndex.Value>0 && nextItemIndex>= endIndex.Value)
			{
				nextItemIndex = 0;
				Fsm.Event(finishedEvent);
				return;
			}

			// iterate the next child
			nextItemIndex++;

			if (loopEvent != null)
			{
				Fsm.Event(loopEvent);
			}
		}
		
		
		public void GetItemAtIndex(){
			
			
			if (! isProxyValid())
				return;
		
	
			
			System.Type valueType = null;
			object element = null;
			
			try{
				valueType = proxy.arrayList[nextItemIndex].GetType();
				element = proxy.arrayList[nextItemIndex];
			}catch(System.Exception e){
				Debug.LogError(e.Message);
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