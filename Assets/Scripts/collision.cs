using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class collision : MonoBehaviour
{
	public Transform player;
	public Transform canvasEnd;
	public static bool ended = false;
	Vector3 pLocation, eLocation, pPos;

	void Update() 
	{
		pLocation = GameObject.Find ("FPSController").transform.position;
		eLocation = GameObject.Find ("endObject").transform.position;

		if (Vector3.SqrMagnitude (pLocation - eLocation) < 1) 
		{
			for (int i = 0; i < 10; i++) 
			{
				gameEnd ();
			}
		}
	}

	public void gameEnd() 
	{
		Debug.Log ("HIT");
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("mazePart");
		GameObject[] endObj = GameObject.FindGameObjectsWithTag("endObject");

		removeGameObj (gameObjects);
		removeGameObj (endObj);
	}

	public void removeGameObj(GameObject[] gObj)
	{
		foreach (GameObject target in gObj) 
		{
			GameObject.Destroy(target);

			ended = true;
			canvasEnd.gameObject.SetActive (true);
			Time.timeScale = 0;
			player.GetComponent<FirstPersonController> ().enabled = false;
			Cursor.visible = true;
		}
	}
}