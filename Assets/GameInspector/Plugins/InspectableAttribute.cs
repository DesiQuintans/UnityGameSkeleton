using System;

[AttributeUsage(AttributeTargets.Field)]
public class InspectableAttribute : System.Attribute
{
	//niceName is the name displayed in the inspector window.
	public string niceName = "";
	//rank is the order of the value in the inspector window.
	public int rank = 0;
	public InspectableAttribute(string niceName, int rank) {
		this.niceName = niceName;
		this.rank = rank;
	}
}