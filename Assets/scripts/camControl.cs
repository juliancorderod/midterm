using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.IO;

public class camControl : MonoBehaviour {

	Camera cam;

	public GameObject cam2;

	public bool endPic = false;
	public static bool takenPic = false;
	public static bool takingPic = false;

	public static bool actuallyTakingPic = false;
	public static bool takingFirstPic = false;
	public static bool takenFirstPic = false;
	public static bool activateShift = false;

	public bool liftCamTrue = false;
	public static bool liftCamTrueFirst = false;
	public int shutterSpeed;

	public static bool musicStart = false;

	public static int picNumber = 0;

	public GameObject cameraMesh;
	public GameObject camFrame;

	public GameObject shuttText;
	public GameObject picsLeftText;
	public GameObject fovText;

	public static int picsLeft = 10;

	float camMovLerp = 0f;

	public float upDownLook = 0f;

	//public RenderTexture rendText1;

	public static float rotationVal = 100f;

	public showPicReal gallery;

	public GameObject darkBox;

	public GameObject rotateThingy;

	public GameObject shutt1Sound;
	public GameObject shutt2Sound;

	public GameObject rewindCam;

	public GameObject titleObj;


	bool saveToTexture = false;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();

		cam.cullingMask = (1 << 0 | 1 << 8);

		//rendText1.width = Screen.width;
		//rendText1.height = Screen.height;

		darkBox.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)){

			Application.Quit();

		}

		Cursor.lockState = CursorLockMode.Locked;

		cameraMesh.transform.localPosition = new Vector3(Mathf.Lerp(0.11f, 0,camMovLerp), Mathf.Lerp( 0.19f, 0.5f,camMovLerp), Mathf.Lerp(0.82f, 0.5f,camMovLerp));

		if(Input.GetKeyDown(KeyCode.Tab) && !takingPic){
			//&& !actuallyTakingPic){

			//camMovLerp += 1f * Time.deltaTime;

			liftCamTrue = true; 
			liftCamTrueFirst = true;

			titleObj.SetActive (false);

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
			if(Input.GetKey(KeyCode.X) && cam.fieldOfView <= 90f){

				cam.fieldOfView += 15f * Time.deltaTime;

			}

		}



		if (takenPic) {

			//StartCoroutine (takenPicCoroutine());

//			shutt2Sound.GetComponent<AudioSource>().Play();

			cam.clearFlags = CameraClearFlags.SolidColor;
			cam.cullingMask = (1 << 0 | 1 << 8);
			cam.fieldOfView = 60;
			takenPic = false;

			rotationVal = 100f;

			actuallyTakingPic = false;

			camFrame.SetActive(true);

			liftCamTrue = false;

			StartCoroutine (camBack());
			activateShift = true;
			takenFirstPic = true;

			cameraMesh.GetComponent<Animator>().Play("rewindCam");

			//rewindCam.GetComponent<Animation>().Play();



//			if (rotateThingy.transform.localEulerAngles.y >= -70f){
//
//			rotateThingy.transform.localEulerAngles += new Vector3 (0, - 1 * Time.deltaTime , 0);
//
//			}
			//**************************
			//hacer ienum coso

		}



		shuttText.GetComponent<Text>().text = shutterSpeed + "";
		fovText.GetComponent<Text>().text = Mathf.Round(cam.fieldOfView) + "";


		picsLeft = 9 - picNumber;

		if (picsLeft == 0){

			picsLeftText.GetComponent<Text>().text = "0";

		} else{

			picsLeftText.GetComponent<Text>().text = picsLeft + "";

		}



		if (Input.GetKeyDown(KeyCode.E) && !actuallyTakingPic && shutterSpeed  <= 29){

			shutterSpeed += 1;

		}
		if (Input.GetKeyDown(KeyCode.Q) && !actuallyTakingPic && shutterSpeed  >= 1){

			shutterSpeed -= 1;

		}

		//Debug.Log(rotationVal);



		// cheattssssssssss wujuuuu

		if (Input.GetKey(KeyCode.Alpha1)){

			GetComponent<Fisheye>().enabled = true;


		}else {

			GetComponent<Fisheye>().enabled = false;

		}

		if (Input.GetKey(KeyCode.Alpha2)){

			GetComponent<ColorCorrectionCurves>().enabled = true;


		}else {

			GetComponent<ColorCorrectionCurves>().enabled = false;

		}

		if (Input.GetKey(KeyCode.Alpha3)){

			GetComponent<ColorCorrectionLookup>().enabled = true;


		}else {

			GetComponent<ColorCorrectionLookup>().enabled = false;

		}
		if (Input.GetKey(KeyCode.Alpha4)){

			GetComponent<VignetteAndChromaticAberration>().enabled = true;


		}else {

			GetComponent<VignetteAndChromaticAberration>().enabled = false;

		}
		if (Input.GetKey(KeyCode.Alpha5)){

			GetComponent<ContrastEnhance>().enabled = true;


		}else {

			GetComponent<ContrastEnhance>().enabled = false;

		}

	}




	public IEnumerator liftCam(){

		//shuttText.SetActive(false);
		//picsLeftText.SetActive(false);

		camMovLerp += 1f * Time.deltaTime;

		while (camMovLerp <= 1f){

			yield return null;
		}
			

		cameraMesh.SetActive(false);

		takingPic = true;

		camFrame.SetActive(true);
		musicStart = true;


		//GetComponent<BlurOptimized>().enabled = true;

	}

	public IEnumerator camBack(){


		transform.localEulerAngles = new Vector3(0,0.75f,0);

		camFrame.SetActive(false);


		GetComponent<BlurOptimized>().enabled = false;

		camMovLerp -= 1.5f * Time.deltaTime;


		while (camMovLerp <= 0.8f){

			yield return null;
		}

		cameraMesh.SetActive(true);

		takingPic = false;

		//shuttText.SetActive(true);
		//picsLeftText.SetActive(true);

	}


	public IEnumerator startPic(){



		camFrame.SetActive(false);

		shutt1Sound.GetComponent<AudioSource>().Play();

		//cam.targetTexture = rendText1;

		takingFirstPic = true;

		while (camFrame.activeSelf == true){

			yield return null;
		}

		yield return new WaitForSeconds(0.05f);

		GetComponent<BlurOptimized>().enabled = true;

		//cam.depth = 0;
		//cam2.SetActive (true);
		//cam2.GetComponent<Camera>(). targetTexture = rendText1;

		actuallyTakingPic = true;

		picNumber += 1;
		rotationVal = 25f;

		cam.clearFlags = CameraClearFlags.Nothing;


		while (cam.clearFlags == CameraClearFlags.SolidColor){

			yield return null;
		}

		yield return new WaitForSeconds(0.05f);



		cam.cullingMask = (1 << 0);//this ignores cars






		yield return new WaitForSeconds(shutterSpeed);

		//cam.depth = 1;




		//endPic = true;

		//Application.CaptureScreenshot( "Assets/Resources/pic" + picNumber + ".png");
//		gallery.pic1 = new Texture2D (rendText1.width, rendText1.height);
//		gallery.pic1.ReadPixels(new Rect(0, 0, rendText1.width, rendText1.height), 0, 0);
//		gallery.pic1.Apply();

		saveToTexture = true;

		//cam2.SetActive (false);
		shutt2Sound.GetComponent<AudioSource>().Play();

		while (saveToTexture == false){

			yield return null;
		}

		yield return new WaitForSeconds(0.5f);
		takenPic = true;


		//StartCoroutine (camBack());



	}

	void OnPostRender(){
		if (saveToTexture){
//			gallery.pic1 = new Texture2D (rendText1.width, rendText1.height);
//			gallery.pic1.ReadPixels(new Rect(0, 0, rendText1.width, rendText1.height), 0, 0);

			if(showPicReal.picShown == 1){

				gallery.pic1 = new Texture2D (Screen.width, Screen.height);
				gallery.pic1.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic1.Apply();

				byte[] bytes1 = gallery.pic1.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic1.png", bytes1);

			}
			if(showPicReal.picShown == 2){

				gallery.pic2 = new Texture2D (Screen.width, Screen.height);
				gallery.pic2.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic2.Apply();

				byte[] bytes2 = gallery.pic2.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic2.png", bytes2);

			}
			if(showPicReal.picShown == 3){

				gallery.pic3 = new Texture2D (Screen.width, Screen.height);
				gallery.pic3.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic3.Apply();

				byte[] bytes3 = gallery.pic3.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic3.png", bytes3);

			}
			if(showPicReal.picShown == 4){

				gallery.pic4 = new Texture2D (Screen.width, Screen.height);
				gallery.pic4.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic4.Apply();

				byte[] bytes4 = gallery.pic4.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic4.png", bytes4);

			}
			if(showPicReal.picShown == 5){

				gallery.pic5 = new Texture2D (Screen.width, Screen.height);
				gallery.pic5.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic5.Apply();

				byte[] bytes5 = gallery.pic5.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic5.png", bytes5);

			}
			if(showPicReal.picShown == 6){

				gallery.pic6 = new Texture2D (Screen.width, Screen.height);
				gallery.pic6.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic6.Apply();

				byte[] bytes6 = gallery.pic6.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic6.png", bytes6);

			}
			if(showPicReal.picShown == 7){

				gallery.pic7 = new Texture2D (Screen.width, Screen.height);
				gallery.pic7.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic7.Apply();

				byte[] bytes7 = gallery.pic7.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic7.png", bytes7);

			}
			if(showPicReal.picShown == 8){

				gallery.pic8 = new Texture2D (Screen.width, Screen.height);
				gallery.pic8.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic8.Apply();

				byte[] bytes8 = gallery.pic8.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic8.png", bytes8);

			}
			if(showPicReal.picShown == 9){

				gallery.pic9 = new Texture2D (Screen.width, Screen.height);
				gallery.pic9.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
				gallery.pic9.Apply();

				byte[] bytes9 = gallery.pic9.EncodeToPNG();
				File.WriteAllBytes(Application.dataPath +"/../../SavedPics/pic9.png", bytes9);

			}


			saveToTexture = false;

		}


	}



}
