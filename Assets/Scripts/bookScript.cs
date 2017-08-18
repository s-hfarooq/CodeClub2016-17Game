using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class bookScript : MonoBehaviour {


	public Transform player;
	public Transform book;	
	Vector3 pLocation, bLocation, pPos;
	public Transform canvas;
	public GameObject gObject;


	public Text message;// = "Zoo welcome research, which adults he Zoo from the people. She got a Yam only rise. I am Chinese and die. iuhgresighseiudbgersubg"; 
	public string message2 = "It is designed for all Andrew he is a shit face. He is a nigger and a jew. fuck him. filthy mexicant";

	void Start () {
		message = gameObject.GetComponent<Text>();
		message.text = message2; 
	}

	void Update()
	{
		pLocation = GameObject.Find ("FPSController").transform.position;
		//bLocation = GameObject.Find ("bObject").transform.position;

		if (Vector3.SqrMagnitude (pLocation - bLocation) < 1) 
		{
			if(Input.GetKeyDown ("f"))
			{							
				displayMessage ();
			}
		}
	}

	public void displayMessage()
	{
		message = GetComponent<Text>();
		message.text = "Zoo welcome research, which adults he Zoo from the people. She got a Yam only rise. I am Chinese and die. iuhgresighseiudbgersubg"; 

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

}
