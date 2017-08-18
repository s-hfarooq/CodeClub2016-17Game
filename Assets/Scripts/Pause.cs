using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {
	public Transform player;
	public Transform canvas;
	public Transform canvasEnd;
	public static bool endDone = false;
	
	void Update () {
		endDone = collision.ended;

		if (Input.GetKeyDown (KeyCode.Escape) && endDone == false) {
			gamePause ();
			Cursor.visible = true;
		}
	}

	public void gamePause() {
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive (true);
			Time.timeScale = 0;
			player.GetComponent<FirstPersonController> ().enabled = false;
			Cursor.visible = true;
		} else {
			canvas.gameObject.SetActive (false);
			Time.timeScale = 1;
			player.GetComponent<FirstPersonController> ().enabled = true;
			Cursor.visible = false;
		}
	}

	public void gameQuit() {
		Application.Quit ();
	}

	public void mainMenu() {
		SceneManager.LoadScene ("MainMenu");
	}
}
