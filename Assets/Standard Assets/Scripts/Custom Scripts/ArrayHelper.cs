using UnityEngine;
using System.Collections;

public static class ArrayHelper {

	public static bool isIndexValid (string[] thisArray, int row, int column)
	{
		// Subtracting 1 to make lengths match index.
		int numberOfRows = thisArray.Length - 1;
		
		// Must check the number of rows at this point, or else an OutOfRange exception gets thrown when checking number of columns.
		if (row > numberOfRows || row < 0) return false;

		int numberOfColumns = thisArray[row].Length - 1;
		
		if (column > numberOfColumns || column < 0) return false;
		else return true;
	}
	
	public static bool areSurroundingsValid (string[] thisArray, int row, int column)
	{
			/*
			DOC: areSurroundingsValid
				Checks if the array indexes in the cardinal directions around the given index exist.
			*/
			if (isIndexValid (thisArray, (row-1), column) == false) return false;
			else if (isIndexValid (thisArray, (row+1), column) == false) return false;
			else if (isIndexValid (thisArray, row, (column-1)) == false) return false;
			else if (isIndexValid (thisArray, row, (column+1)) == false) return false;
			else return true;
	}
}
