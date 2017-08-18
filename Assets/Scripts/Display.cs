using UnityEngine;
using System.Collections;

public class Display : MonoBehaviour {
	public GameObject[] shapes;
	public GameObject player;
	public GameObject endPoint;
	public GameObject roomObject;
	private MapGenerator mapGenerator;
	public float minimumMazePercentage = 0.6f;
	static int rTr, rTc, rTr2, rTc2;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		mapGenerator = GetComponent<MapGenerator> ();

		int visitedCellCount = 0;
		bool[,] visitedCells = new bool[mapGenerator.mapRows, mapGenerator.mapColumns];

		int minimumMazeCells = Mathf.FloorToInt((mapGenerator.mapRows - 2) * (mapGenerator.mapColumns - 2) * minimumMazePercentage);

		while (visitedCellCount < minimumMazeCells) {
			Debug.Log ("Current size = " + visitedCellCount + ", less than required " + minimumMazeCells + ". Retrying");
			mapGenerator.InitializeMap ();
			visitedCells = mapGenerator.TraverseMap ();
			visitedCellCount = GetVisitedCellsCount (visitedCells);
			Debug.Log ("visited count = " + visitedCellCount);
		}

		mapGenerator.DisplayMap ();

		for (int r = 1; r < mapGenerator.mapRows-1; r++) {
			for (int c = 1; c < mapGenerator.mapColumns - 1; c++) {
				string ch = mapGenerator.map [r, c].ToString();
				int charPos = mapGenerator.boxCharacters.IndexOf (ch);

				if (ch.Equals("@") || ch.Equals("˂") || ch.Equals("˃") || ch.Equals("˅") || ch.Equals("˄")) {
					Instantiate (roomObject, new Vector3 (r * 3, 0, c * 3), roomObject.transform.rotation);
				} else	if (charPos < 0 || !visitedCells [r, c]) {
					continue;		
					endPoint.transform.position = new Vector3 (Display.rTr2, 0, 3);

				} else {
					Instantiate (shapes [charPos], new Vector3 (r * 3, 0, c * 3), shapes [charPos].transform.rotation);
					if (r == 1) {
						rTr = r * 3;
						rTc = c * 3;
						player.transform.position = new Vector3 (Display.rTr, 0, Display.rTc);
					} 
				}
			}
		}
		rTr2 = (mapGenerator.mapRows - 2) * 3;
		rTc2 = (mapGenerator.mapColumns - 2) * 3;
		endPoint.transform.position = new Vector3 (Display.rTr2, 0, 3);


	}

	private int GetVisitedCellsCount(bool[,] visitedCells) {
		int visitedCellsCount = 0;

		for (int r = 1; r < mapGenerator.mapRows - 1; r++) {
			for (int c = 1; c < mapGenerator.mapColumns - 1; c++) {
				if (visitedCells [r, c]) {
					visitedCellsCount++;
				}
			}
		}
		return visitedCellsCount;
	}
}