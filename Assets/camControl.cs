using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControl : MonoBehaviour {

	Camera cam;

	public bool endPic = false;
	public bool takenPic = false;
	public bool takingPic = false;

	public bool liftCamTrue = false;

	public int shutterSpeed;

	public GameObject cameraMesh;
	public GameObject camFrame;

	float camMovLerp = 0f;




	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();



	}
	
	// Update is called once per frame
	void Update () {



//		cameraMesh.transform.localPosition = new Vector3(Mathf.Lerp(cameraMesh.transform.localPosition.x, 0,camMovLerp), 
//			Mathf.Lerp(cameraMesh.transform.localPosition.y, 0.5f,camMovLerp),
//			Mathf.Lerp(cameraMesh.transform.localPosition.z, 0.5f,camMovLerp));

		cameraMesh.transform.localPosition = new Vector3(Mathf.Lerp(0.11f, 0,camMovLerp), Mathf.Lerp( 0.19f, 0.5f,camMovLerp), Mathf.Lerp(0.82f, 0.5f,camMovLerp));

		if(Input.GetKeyDown(KeyCode.Tab) && !takingPic){

			//camMovLerp += 1f * Time.deltaTime;

			liftCamTrue = true; 
		}
		if (liftCamTrue && camMovLerp <= 1){

			StartCoroutine (liftCam());

		}
		if(Input.GetKeyDown(KeyCode.Tab) && takingPic){
			
			liftCamTrue = false;
		}
		if (!liftCamTrue && camMovLerp >= 0){

			StartCoroutine (camBack());

		}

//		if(!Input.GetKey(KeyCode.Tab) && !takingPic){
//
//			camMovLerp -= 0.5f * Time.deltaTime;
//
//		}


		if(Input.GetKeyDown(KeyCode.Space) && takingPic){


			StartCoroutine (startPic());


		} 



		if (takenPic) {

			cam.clearFlags = CameraClearFlags.SolidColor;
			takenPic = false;
		}

		Debug.Log(camMovLerp);




	}

	public IEnumerator liftCam(){

		camMovLerp += 1f * Time.deltaTime;

		while (camMovLerp <= 1f){

			yield return null;
		}
			

		cameraMesh.SetActive(false);

		takingPic = true;

		camFrame.SetActive(true);
	}

	public IEnumerator camBack(){

		camFrame.SetActive(false);

		camMovLerp -= 1f * Time.deltaTime;

		while (camMovLerp <= 0.8f){

			yield return null;
		}

		cameraMesh.SetActive(true);

		takingPic = false;

	}


	public IEnumerator startPic(){


		cam.clearFlags = CameraClearFlags.Nothing;

		yield return new WaitForSeconds(shutterSpeed);

		//endPic = true;
		Application.CaptureScreenshot( "Assets/Resources/pic 1.png");

		yield return new WaitForSeconds(0.5f);
		takenPic = true;

	}
}
