using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class runMain : MonoBehaviour {

	void Start() {
		Cursor.visible = true;
	}
	
	public void startMain() {
		SceneManager.LoadScene ("MainGame");
		Cursor.visible = false;
	}

	public void gameQuit() 
	{
		Application.Quit ();
	}
}