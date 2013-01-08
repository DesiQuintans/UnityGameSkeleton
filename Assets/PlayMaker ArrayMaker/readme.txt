(c) Jean Fabre, 2011-2012 All rights reserved.
http://www.fabrejean.net
contact: http://www.fabrejean.net/contact.htm

ArrayMaker Addon for PlayMaker. Version Alpha 0.9

changes from 0.7
 WARNING: previous version had a different file organisation, so now it sits in its own folder and not within "PlayMaker" which was a mistake, 
 I assumed actions would only be detected if within the Actions folder...
-- goes to 0.9 because I can :) well I had a 0.8 version sort of, but so much went that I moved to 0.9
-- new actions
-- incorporate fixes for Texture and proceduralMaterial assignment
-- fixed prefab instance editing not serializing properly
-- fixed ArrayListCopyTo action

changes from 0.6
-- now using gamObject for reference instead of the component itself via fsmObject, since this doesn't bring any advantages ( as we still need a string reference...)


DESCRIPTION:
ArrayMaker Addon provide the ability for PlayMaker to work with ArrayLists and HashTables. 
ArrayLists and HashTables are defined as proxy components on GameObjects: They can be referenced within Fsm using a gameObject referemce, a string reference and the related custom actions.
A full set of Custom Actions is available to work with those ArrayLists and HashTables proxies. 
ArrayLists and HashTables proxies can be created at runtime within Fsm for convenience ( a set of Actions is available for this).

Features of ArrayLists and HashTables proxies: 
	* You can fill ArrayLists and Hashtables with content during authoring.
	* You can live preview and edit content of ArrayLists and Hashtables.
	* hashtable inspector check and visually warn for key duplicates.
	* during playback, you can narrow the preview given a start index and a row count, so if you have thousands of entrys, it is still manageable in the inspector.

NOTE: ArrayLists and HashTables proxy components can be used and accessed by normal scripts as well. 

More info on the PlayMaker forum dedicated section ( not yet available )


INSTALLATION:

***************** WARNING: PLAYMAKER NEEDS TO BE INSTALL. *******************
 You must own PlayMaker to use all the customs actions created
*****************************************************************************

 
To install ArrayMaker Addon for PlayMaker unpack the unitypackage.
To see sample scenes, import the included ArrayMakerSamples.unitypackage.	


KNOWN ISSUES:
	
		
TOASK ALEX:
	* It is very cumbersone currently to expose all possible fsm variable type in the inspector ( arrayListAdd for a typical example). The user must first select the type from the popup and then fill the right onw within all the available ones.
	 this is not ideal. Could it be possible to improve the situation? like having something like a FsmAny GUI system where the user select a gui type and is presented only with the appropriate gui for that type. Maybe as an attribute like compound arrays? I'd settle for this and all the switch statements if the gui can be cleaner.
	FsmAny[] would be also extra cool so that we can let the user define several distinct FsmVariable ( arrayListAddRange).
	* Is it possible to gain access even via raw commandline to the help generator to document each actions on the wiki ( pretty please :) )
	* playmaker Addon menu ? so that we can have menu item right within the playmaker menu, this would be nice. I tried but I have difficulties controlling the order...
	* I used the same font for the "arrayMaker" logo. Is that acceptable? I am ok to change it of course, I just messed with it and had this idea since "a" "y" and "r was available in your logo :)
	
TOASK :
	* when getting an item from list, should it convert automatically and if possible to the type set in the get value?
		ie: arrayList[2] contains a int. If the arrayListGet is set to retrieve a string, should I convert? maybe have an explicit flag to allow for this?
	* Actions are implemented in a strict manner, that is HashTableAdd will not "set" instead if the key already exists. 
	* Some actions have events such as Success, Found, NotFound. I need a clear and consistent behavior here, but unsettled about this. for example: if I expose a NoFound event ( exmaple ArraListRemove), should I expose a Found event as well or simply rely on the built in Finish event? I tend to think the more the better ( FOUND & NOTFOUND) but actions starts to be crowded with optionnal stuff, this could be misleading for beginners.
	* should I use DEFINE in my proxies so that if the user doesn't have playmaker he can still benefit from my proxies ( cause they offers features not available with conventionnal arrays).
	
TOFIX:
	* broadcast events to fsm from wrappers. Is it possible without a Fsm reference? it should I think. -> will implement with the new api when available
	* how can I improve the hashTableActions and ArrayTableActions to avoid duplicate code just because the type is different, 
	the routine is identical to get and check for a component on a gameObject.
	* How PlayMaker LogError is working? I can't get anything, I have to use debug.LogError.
	
ROADMAP:
	* more collections type if required
	* more tools to build arrays during authoring and playback : add, insert, remove, remove at, and change type for each entry.
	* possible specialties for GUI listing and stuff ( like drop down menu)

Similar Addons down the line:
	* XML Parser -> REST?
	* json Parser ?
	* CSV Parser ( definitly, with headers etc etc)
	* rss parser?
	* database bridge?