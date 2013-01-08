//	(c) Jean Fabre, 2011-2012 All rights reserved.
//	http://www.fabrejean.net
// 
// Version Alpha 0.9
//

//using UnityEditor;
using UnityEngine;
using HutongGames.PlayMaker;
using System.Collections;
using System.Collections.Generic;

public abstract class PlayMakerCollectionProxy : MonoBehaviour {
	
	/*
	[MenuItem ("PlayMaker/Addon/Collections/About Collections")]
    static void about () {
		//TODO
    }
	*/
	
	public enum VariableEnum{
		 GameObject,Int,Float,String,Bool,Vector3,Rect,Quaternion,Color,Material,Texture
	}
		
	//- EDITING STUFF
	// TODO: I put them here cause they don't serialize otherwise: need to learn how to serialize...
	public bool showEvents = false;
	public bool showContent = false;
	public bool TextureElementSmall = false;
	public bool condensedView = false;
	public bool liveUpdate = false;
	//-
	
	// the reference Name used when finding or when several component coexists on the same GameObject
	public string referenceName = "";
	
	// broadcast events to Fsm
	public bool enablePlayMakerEvents = false;
	public string addEvent;
	public string setEvent;
	public string removeEvent;

	public int contentPreviewStartIndex = 0;
	public int contentPreviewMaxRows = 10;
	
	
	// author time array definition
	// experimenting right now
	// TOFIX: I can't find a way to define a editor gui element for a list... odd
	// so now, have to roll my own listing system... not cool	
	public VariableEnum preFillType;
	public int preFillObjectTypeIndex; // FsmEditorUtility.ObjectTypeList[preFillObjectTypeIndex]
	public int preFillCount;
	
	// Hastable keys
	public List<string> preFillKeyList = new List<string>();
	

	// TODO: improve the situation by maintaining an array of prefills, or a better way to code this without having to switch case for each type...
	public List<bool> preFillBoolList = new List<bool>();
	public List<Color> preFillColorList = new List<Color>();
	public List<float> preFillFloatList = new List<float>();
	public List<GameObject> preFillGameObjectList = new List<GameObject>();
	public List<int> preFillIntList = new List<int>();
	public List<Material> preFillMaterialList = new List<Material>();
	public List<Object> preFillObjectList = new List<Object>();
	public List<Quaternion> preFillQuaternionList = new List<Quaternion>();
	public List<Rect> preFillRectList = new List<Rect>();
	public List<string> preFillStringList = new List<string>();
	public List<Texture2D> preFillTextureList = new List<Texture2D>();
	public List<Vector3> preFillVector3List = new List<Vector3>();
	
	
	internal void dispatchEvent(string anEvent,object value,string type)
	{
		if (!enablePlayMakerEvents)
		{
			return;
		}
		switch (type){
				case ("bool"):
					Fsm.EventData.BoolData = (bool)value;
					break;
				case ("color"):
					Fsm.EventData.ColorData = (Color)value;
					break;
				case ("float"):
					Fsm.EventData.FloatData = (float)value;
					break;
				case ("gameObject"):
					Fsm.EventData.ObjectData = (GameObject)value;
					break;
				case ("int"):
					Fsm.EventData.IntData = (int)value;
					break;
				case ("material"):
					Fsm.EventData.MaterialData = (Material)value;
					break;
				case ("object"):
					Fsm.EventData.ObjectData = (Object)value;
					break;
				case ("quaternion"):
					Fsm.EventData.QuaternionData = (Quaternion)value;
					break;
				case ("rect"):
					Fsm.EventData.RectData = (Rect)value;
					break;
				case ("string"):
					Fsm.EventData.StringData = (string)value;
					break;
				case ("texture"):
					Fsm.EventData.TextureData = (Texture)value;
					break;
				case ("vector3"):
					Fsm.EventData.Vector3Data = (Vector3)value;
					break;
				default:
					//ERROR
					break;
				
			}
		
		FsmEventTarget eventTarget = new FsmEventTarget();
		eventTarget.target = FsmEventTarget.EventTarget.BroadcastAll;
		
		var fsmList = new List<Fsm>(Fsm.FsmList);
		if (fsmList.Count>0){
			Fsm fsmOne = fsmList[0];
			fsmOne.Event(eventTarget,anEvent);
		}
			//foreach (var fsm in fsmList){fsm.Event(anEvent);}
	}
	
	
	public void cleanPrefilledLists(){
		
	  	 // trim the preFilled lists
		// during editing, if you mess with the count, you would loose entries, instead it keeps track of everything until you actually
		// commit into play or something. Maybe there is a better method then OnEnable for this.
		// it keeps also track of any types list.

		
		if (preFillBoolList.Count>preFillCount){
			preFillBoolList.RemoveRange(preFillCount,(preFillBoolList.Count-preFillCount));
		}
		if (preFillColorList.Count>preFillCount){
			preFillColorList.RemoveRange(preFillCount,(preFillColorList.Count-preFillCount));
		}		
		if (preFillFloatList.Count>preFillCount){
			preFillFloatList.RemoveRange(preFillCount,(preFillFloatList.Count-preFillCount));
		}		
		if (preFillIntList.Count>preFillCount){
			preFillIntList.RemoveRange(preFillCount,(preFillIntList.Count-preFillCount));
		}		
		if (preFillMaterialList.Count>preFillCount){
			preFillMaterialList.RemoveRange(preFillCount,(preFillMaterialList.Count-preFillCount));
		}		
		if (preFillObjectList.Count>preFillCount){
			preFillObjectList.RemoveRange(preFillCount,(preFillObjectList.Count-preFillCount));
		}
		if (preFillQuaternionList.Count>preFillCount){
			preFillQuaternionList.RemoveRange(preFillCount,(preFillQuaternionList.Count-preFillCount));
		}
		if (preFillRectList.Count>preFillCount){
			preFillRectList.RemoveRange(preFillCount,(preFillRectList.Count-preFillCount));
		}
		if (preFillStringList.Count>preFillCount){
			preFillStringList.RemoveRange(preFillCount,(preFillStringList.Count-preFillCount));	
		}
		if (preFillTextureList.Count>preFillCount){
			preFillTextureList.RemoveRange(preFillCount,(preFillTextureList.Count-preFillCount));	
		}
		if (preFillVector3List.Count>preFillCount){
			preFillVector3List.RemoveRange(preFillCount,(preFillVector3List.Count-preFillCount));	
		}
		
	}// cleanPrefilledLists
	
	
}
