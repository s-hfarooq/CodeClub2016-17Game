using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class textInput : MonoBehaviour {

	public InputField iField;
	public Canvas textCanvas;
	public string text;
	public static int rows = 0;
	bool gotInput = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gotInput == false)
		{
			if (Input.GetKeyDown ("return") || Input.GetKeyDown ("enter"))
				getText ();
		}	
	}

	void getText() {
		if (gotInput == false) 
		{
			text = iField.text;
			Debug.Log ("text: " + text + ". ");
			rows = int.Parse (text);
			Debug.Log ("int: " + rows + ". ");

			iField.enabled = false; 
			Destroy(textCanvas);
			gotInput = true; 
		}
	}
}