using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camControl : MonoBehaviour {

	Camera cam;

	public bool endPic = false;
	public static bool takenPic = false;
	public static bool takingPic = false;

	public bool liftCamTrue = false;

	public int shutterSpeed;

	public GameObject cameraMesh;
	public GameObject camFrame;

	public GameObject shuttText;

	float camMovLerp = 0f;

	float upDownLook = 0f;


	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();


	}
	
	// Update is called once per frame
	void Update () {

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
		if(Input.GetKeyDown(KeyCode.Space) && takingPic){


			StartCoroutine (startPic());


		} 

		if(takingPic){

			upDownLook -= Input.GetAxis("Mouse Y") * Time.deltaTime * 180f;
			upDownLook = Mathf.Clamp(upDownLook,-80f,80f);

			transform.eulerAngles = new Vector3(upDownLook, transform.eulerAngles.y,0);

		}



		if (takenPic) {

			cam.clearFlags = CameraClearFlags.SolidColor;
			takenPic = false;
		}



		shuttText.GetComponent<Text>().text = shutterSpeed + "";



		if (Input.GetKeyDown(KeyCode.E) && !takingPic){

			shutterSpeed += 1;

		}
		if (Input.GetKeyDown(KeyCode.Q) && !takingPic){

			shutterSpeed -= 1;

		}

		Debug.Log(shutterSpeed);

	}

	public IEnumerator liftCam(){

		shuttText.SetActive(false);

		camMovLerp += 1f * Time.deltaTime;

		while (camMovLerp <= 1f){

			yield return null;
		}
			

		cameraMesh.SetActive(false);

		takingPic = true;

		camFrame.SetActive(true);
	}

	public IEnumerator camBack(){


		transform.localEulerAngles = new Vector3(0,0.75f,0);

		camFrame.SetActive(false);

		camMovLerp -= 1f * Time.deltaTime;


		while (camMovLerp <= 0.8f){

			yield return null;
		}

		cameraMesh.SetActive(true);

		takingPic = false;

		shuttText.SetActive(true);

	}


	public IEnumerator startPic(){


		cam.clearFlags = CameraClearFlags.Nothing;

		yield return new WaitForSeconds(shutterSpeed);

		//endPic = true;
		Application.CaptureScreenshot( "Assets/Resources/pic 1.png");

		yield return new WaitForSeconds(0.5f);
		takenPic = true;

	}

//	public IEnumerator changeShutter(){
//
//
//
//	}


}
