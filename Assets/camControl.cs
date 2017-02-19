using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour {

	Camera cam;

	public bool endPic = false;
	public bool takenPic = false;

	public int shutterSpeed;



	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){

			cam.clearFlags = CameraClearFlags.Nothing;

			StartCoroutine (startPic());

		} 
		//if(Input.GetKeyUp(KeyCode.Space)){
//		if(endPic){
//
//			Application.CaptureScreenshot( "Assets/Resources/pic 1.png");
//			takenPic = true;
//		}


		if (takenPic) {

			cam.clearFlags = CameraClearFlags.SolidColor;
			takenPic = false;
		}
		
	}

	public IEnumerator startPic(){

		yield return new WaitForSeconds(shutterSpeed);

		//endPic = true;
		Application.CaptureScreenshot( "Assets/Resources/pic 1.png");

		yield return new WaitForSeconds(0.5f);
		takenPic = true;

	}
}
