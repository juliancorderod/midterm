using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPicReal : MonoBehaviour {

	public GameObject camObject;
	public GameObject greyOut;
	public GameObject blackBackground;

	public static bool picOn = false;

	public int picShown;

	public GameObject pic1Obj, pic2Obj, pic3Obj, pic4Obj, pic5Obj, pic6Obj, pic7Obj, pic8Obj, pic9Obj;

	public Texture2D pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9; 

	public RawImage realPic1, realPic2, realPic3, realPic4, realPic5, realPic6, realPic7, realPic8, realPic9, realAllPics;
	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(picShown);

		//if(camObject.GetComponent<camControl>().takenPic){

		picShown  = camControl.picNumber;

		if(camControl.takenPic){

//			UnityEditor.AssetDatabase.Refresh();
//
//
//			Texture allPics = (Texture2D) Resources.Load ("pic" + picShown);
//			GetComponent<RawImage>().texture = allPics;
//
//			Texture pic1 = (Texture2D) Resources.Load ("pic1");
//			Texture pic2 = (Texture2D) Resources.Load ("pic2");
//			Texture pic3 = (Texture2D) Resources.Load ("pic3");
//			Texture pic4 = (Texture2D) Resources.Load ("pic4");
//			Texture pic5 = (Texture2D) Resources.Load ("pic5");
//			Texture pic6 = (Texture2D) Resources.Load ("pic6");
//			Texture pic7 = (Texture2D) Resources.Load ("pic7");
//			Texture pic8 = (Texture2D) Resources.Load ("pic8");
//			Texture pic9 = (Texture2D) Resources.Load ("pic9");
//			Texture pic10 = (Texture2D) Resources.Load ("pic10");

			if(pic1 != null){

				realPic1.texture = pic1;

			}
			if(pic2 != null){

				realPic2.texture = pic2;

			}
			if(pic3 != null){

				realPic3.texture = pic3;

			}
			if(pic4 != null){

				realPic4.texture = pic4;

			}
			if(pic5 != null){

				realPic5.texture = pic5;

			}
			if(pic6 != null){

				realPic6.texture = pic6;

			}
			if(pic7 != null){

				realPic7.texture = pic7;

			}
			if(pic8 != null){

				realPic8.texture = pic8;

			}
			if(pic9 != null){

				realPic9.texture = pic9;

			}


//			if (tag == "pic1"){
//			GetComponent<RawImage>().texture = pic1;
//			}
//			if (tag == "pic2"){
//				GetComponent<RawImage>().texture = pic2;
//			}
//			if (tag == "pic3"){
//				GetComponent<RawImage>().texture = pic3;
//			}
//			if (tag == "pic4"){
//				GetComponent<RawImage>().texture = pic4;
//			}
//			if (tag == "pic5"){
//				GetComponent<RawImage>().texture = pic5;
//			}
//			if (tag == "pic6"){
//				GetComponent<RawImage>().texture = pic6;
//			}
//			if (tag == "pic7"){
//				GetComponent<RawImage>().texture = pic7;
//			}
//			if (tag == "pic8"){
//				GetComponent<RawImage>().texture = pic8;
//			}
//			if (tag == "pic9"){
//				GetComponent<RawImage>().texture = pic9;
//			}
//			if (tag == "pic10"){
//				GetComponent<RawImage>().texture = pic10;
//			}
		}

		//Debug.Log(camControl.activateShift);

		if (camControl.picsLeft == 0){

			pic1Obj.transform.position = new Vector3(-190,125,0);
			pic1Obj.transform.localScale = new Vector3(1,1,1);

			pic2Obj.transform.position = new Vector3(0,125,0);
			pic2Obj.transform.localScale = new Vector3(1,1,1);

			pic3Obj.transform.position = new Vector3(190,125,0);
			pic3Obj.transform.localScale = new Vector3(1,1,1);

			pic4Obj.transform.position = new Vector3(-190,0,0);
			pic4Obj.transform.localScale = new Vector3(1,1,1);

			pic5Obj.transform.position = new Vector3(0,0,0);
			pic5Obj.transform.localScale = new Vector3(1,1,1);

			pic6Obj.transform.position = new Vector3(190,0,0);
			pic6Obj.transform.localScale = new Vector3(1,1,1);

			pic7Obj.transform.position = new Vector3(-190,-125,0);
			pic7Obj.transform.localScale = new Vector3(1,1,1);

			pic8Obj.transform.position = new Vector3(0,-125,0);
			pic8Obj.transform.localScale = new Vector3(1,1,1);

			pic9Obj.transform.position = new Vector3(190,-125,0);
			pic9Obj.transform.localScale = new Vector3(1,1,1);



			if (Input.GetKeyDown(KeyCode.LeftShift) && !camControl.actuallyTakingPic && tag != "allPics" && !picOn){ //|| camControl.activatePic){

				picOn = true;

				camControl.activateShift = false;

				GetComponent<RawImage>().enabled = true;

				greyOut.SetActive(true);
				blackBackground.SetActive(true);

			}else{ //if(Input.GetKeyDown(KeyCode.LeftShift) && !camControl.actuallyTakingPic && tag != "allPics" && picOn) {
				GetComponent<RawImage>().enabled = false;
				greyOut.SetActive(false);
				blackBackground.SetActive(false);

				//picOn = false;

			} 
			if (Input.GetKeyDown(KeyCode.LeftArrow) && picShown >= 2){

				picShown -= 1;


			}
			if (Input.GetKeyDown(KeyCode.RightArrow) && picShown <= 8){

				picShown += 1;


			}
		
		} else {

			picShown  = camControl.picNumber;

			if (Input.GetKey(KeyCode.LeftShift) && !camControl.actuallyTakingPic){ //&& tag == "allPics"){

				realPic1.GetComponent<RawImage>().enabled = true;
				greyOut.SetActive(true);
				blackBackground.SetActive(true);

			} else {
				realPic1.GetComponent<RawImage>().enabled = false;
				greyOut.SetActive(false);
				blackBackground.SetActive(false);

			}

		}
		
	}
		
}
