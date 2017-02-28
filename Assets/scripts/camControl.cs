using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camControl : MonoBehaviour {

	Camera cam;

	public GameObject cam2;

	public bool endPic = false;
	public static bool takenPic = false;
	public static bool takingPic = false;

	public static bool actuallyTakingPic = false;

	public bool liftCamTrue = false;
	public int shutterSpeed;

	public static bool musicStart = false;

	public static int picNumber = 0;

	public GameObject cameraMesh;
	public GameObject camFrame;

	public GameObject shuttText;
	public GameObject picsLeftText;

	public static int picsLeft = 10;

	float camMovLerp = 0f;

	public float upDownLook = 0f;

	RenderTexture rendText1;

	public static float rotationVal = 100f;


	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();

		cam.cullingMask = (1 << 0 | 1 << 8);
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.lockState = CursorLockMode.Locked;

		cameraMesh.transform.localPosition = new Vector3(Mathf.Lerp(0.11f, 0,camMovLerp), Mathf.Lerp( 0.19f, 0.5f,camMovLerp), Mathf.Lerp(0.82f, 0.5f,camMovLerp));

		if(Input.GetKeyDown(KeyCode.Tab) && !takingPic){
			//&& !actuallyTakingPic){

			//camMovLerp += 1f * Time.deltaTime;

			liftCamTrue = true; 
		}
		if (liftCamTrue && camMovLerp <= 1){

			StartCoroutine (liftCam());

		}
		if(Input.GetKeyDown(KeyCode.Tab) && takingPic && !actuallyTakingPic){
			
			liftCamTrue = false;
		}
		if (!liftCamTrue && camMovLerp >= 0){

			StartCoroutine (camBack());

		}
		if(Input.GetKeyDown(KeyCode.Space) && takingPic && picsLeft >=1 && !actuallyTakingPic || 
			Input.GetKeyDown(KeyCode.Mouse0) && takingPic && picsLeft >=1 && !actuallyTakingPic){


			StartCoroutine (startPic());


		} 

		if(takingPic){

			upDownLook -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotationVal;
			upDownLook = Mathf.Clamp(upDownLook,-80f,80f);

			//rotationVal = 80;

			transform.eulerAngles = new Vector3(upDownLook, transform.eulerAngles.y,0);

			if(Input.GetKey(KeyCode.Z) && cam.fieldOfView >= 1f){

				cam.fieldOfView -= 15f * Time.deltaTime;

			}
			if(Input.GetKey(KeyCode.X) && cam.fieldOfView <= 60f){

				cam.fieldOfView += 15f * Time.deltaTime;

			}

		}



		if (takenPic) {

			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.cullingMask = (1 << 0 | 1 << 8);
			cam.fieldOfView = 60;
			takenPic = false;

			rotationVal = 100f;

			actuallyTakingPic = false;

		}



		shuttText.GetComponent<Text>().text = shutterSpeed + "";


		picsLeft = 10 - picNumber;

		if (picsLeft == 0){

			picsLeftText.GetComponent<Text>().text = "roll finished";

		} else{

			picsLeftText.GetComponent<Text>().text = picsLeft + "";

		}



		if (Input.GetKeyDown(KeyCode.E) && !takingPic && shutterSpeed  <= 19){

			shutterSpeed += 1;

		}
		if (Input.GetKeyDown(KeyCode.Q) && !takingPic && shutterSpeed  >= 1){

			shutterSpeed -= 1;

		}

		Debug.Log(rotationVal);

	}




	public IEnumerator liftCam(){

		shuttText.SetActive(false);
		picsLeftText.SetActive(false);

		camMovLerp += 1f * Time.deltaTime;

		while (camMovLerp <= 1f){

			yield return null;
		}
			

		cameraMesh.SetActive(false);

		takingPic = true;

		camFrame.SetActive(true);
		musicStart = true;
	}

	public IEnumerator camBack(){


		transform.localEulerAngles = new Vector3(0,0.75f,0);

		camFrame.SetActive(false);

		camMovLerp -= 1.5f * Time.deltaTime;


		while (camMovLerp <= 0.8f){

			yield return null;
		}

		cameraMesh.SetActive(true);

		takingPic = false;

		shuttText.SetActive(true);
		picsLeftText.SetActive(true);

	}


	public IEnumerator startPic(){

		//cam.depth = 0;
		//cam2.SetActive (true);
		//cam.targetTexture = rendText1;

		actuallyTakingPic = true;

		picNumber += 1;
		rotationVal = 30f;

		cam.cullingMask = (1 << 0);//this ignores cars

		cam.clearFlags = CameraClearFlags.Nothing;


		yield return new WaitForSeconds(shutterSpeed);

		//cam.depth = 1;
		//cam2.SetActive (false);


		//yield return new WaitForSeconds(0.1f);
		//endPic = true;
		Application.CaptureScreenshot( "Assets/Resources/pic" + picNumber + ".png");

		yield return new WaitForSeconds(0.5f);
		takenPic = true;



	}


}
