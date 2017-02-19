using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPic : MonoBehaviour {

	public GameObject camObject;



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if(camObject.GetComponent<camControl>().takenPic){

			UnityEditor.AssetDatabase.Refresh();

			Texture pic1 = (Texture2D) Resources.Load ("pic 1");
			GetComponent<RawImage>().texture = pic1;

		}

		if (Input.GetKey(KeyCode.LeftShift)){

			GetComponent<RawImage>().enabled = true;

		} else {
			GetComponent<RawImage>().enabled = false;

		}
		
	}
		
}
