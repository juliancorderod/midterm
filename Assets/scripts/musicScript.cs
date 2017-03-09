using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(camControl.musicStart);

		if (camControl.musicStart){

			GetComponent<AudioSource>().Play();

		}
		
	}
}
