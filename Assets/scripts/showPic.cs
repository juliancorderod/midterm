using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPic : MonoBehaviour {

	public GameObject camObject;
	public GameObject greyOut;

	public static bool picOn = false;

	public int picShown;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(picShown);

		//if(camObject.GetComponent<camControl>().takenPic){

		//picShown  = camControl.picNumber;

		if(camControl.takenPic){

			UnityEditor.AssetDatabase.Refresh();


			Texture allPics = (Texture2D) Resources.Load ("pic" + picShown);
			GetComponent<RawImage>().texture = allPics;

			Texture pic1 = (Texture2D) Resources.Load ("pic1");
			Texture pic2 = (Texture2D) Resources.Load ("pic2");
			Texture pic3 = (Texture2D) Resources.Load ("pic3");
			Texture pic4 = (Texture2D) Resources.Load ("pic4");
			Texture pic5 = (Texture2D) Resources.Load ("pic5");
			Texture pic6 = (Texture2D) Resources.Load ("pic6");
			Texture pic7 = (Texture2D) Resources.Load ("pic7");
			Texture pic8 = (Texture2D) Resources.Load ("pic8");
			Texture pic9 = (Texture2D) Resources.Load ("pic9");
			Texture pic10 = (Texture2D) Resources.Load ("pic10");

			if (tag == "pic1"){
			GetComponent<RawImage>().texture = pic1;
			}
			if (tag == "pic2"){
				GetComponent<RawImage>().texture = pic2;
			}
			if (tag == "pic3"){
				GetComponent<RawImage>().texture = pic3;
			}
			if (tag == "pic4"){
				GetComponent<RawImage>().texture = pic4;
			}
			if (tag == "pic5"){
				GetComponent<RawImage>().texture = pic5;
			}
			if (tag == "pic6"){
				GetComponent<RawImage>().texture = pic6;
			}
			if (tag == "pic7"){
				GetComponent<RawImage>().texture = pic7;
			}
			if (tag == "pic8"){
				GetComponent<RawImage>().texture = pic8;
			}
			if (tag == "pic9"){
				GetComponent<RawImage>().texture = pic9;
			}
			if (tag == "pic10"){
				GetComponent<RawImage>().texture = pic10;
			}
		}

		//Debug.Log(camControl.activateShift);

		if (camControl.picsLeft == 0){

			if (Input.GetKeyDown(KeyCode.LeftShift) && !camControl.actuallyTakingPic && tag != "allPics" && !picOn){ //|| camControl.activatePic){

				picOn = true;

				camControl.activateShift = false;

				GetComponent<RawImage>().enabled = true;

				greyOut.SetActive(true);

			}else{ //if(Input.GetKeyDown(KeyCode.LeftShift) && !camControl.actuallyTakingPic && tag != "allPics" && picOn) {
				GetComponent<RawImage>().enabled = false;
				greyOut.SetActive(false);

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

			if (Input.GetKey(KeyCode.LeftShift) && !camControl.actuallyTakingPic && tag == "allPics"){

				GetComponent<RawImage>().enabled = true;
				greyOut.SetActive(true);

			} else {
				GetComponent<RawImage>().enabled = false;
				greyOut.SetActive(false);

			}

		}
		
	}
		
}
