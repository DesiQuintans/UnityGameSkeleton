Game Inspector
--------------


Step 1: Drag the GameInspectorManager prefab into your scene. You can 
configure the Window Title, the width of the name labels and the position
of the inspector window in this game object.

If you want the inspector window to follow the mouse cursor (like a
tooltip), check the follow mouse box.

Step 2: Add the GameInspector component to any game objects who have
variables that you want to display in the inspector panel. They will need
a collider component attached.

Step 3: In any other components on those game objects, add an attribute to
any public variables you want to show in the inspector. Eg:

[Inspectable("Nice Name", 0)]
public string niceName;

The first argument is the "nice name" which is shown in the inspector. The
second argument is the order, or rank of the value when it is listed in the
inspector.

If you are using JS, the syntax looks like this:

@Inspectable("Nice Name", 0)
public var niceName = "";

Please note, if you are using JS, you will need to move the 
GameInspector/Plugins folder to the root of your project.

Step 4: Press play, and hover over your game objects to see the inspector 
appear.