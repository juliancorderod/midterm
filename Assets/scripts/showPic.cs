using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPic : MonoBehaviour {

	public GameObject camObject;

	public int picShown;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(picShown);

		//if(camObject.GetComponent<camControl>().takenPic){



		if(camControl.takenPic){

			UnityEditor.AssetDatabase.Refresh();

			Texture pic1 = (Texture2D) Resources.Load ("pic" + picShown);
			GetComponent<RawImage>().texture = pic1;

		}



//		if (camControl.picsLeft == 0){
//
//			if (Input.GetKey(KeyCode.LeftShift) && picShown >= 0){
//
//				GetComponent<RawImage>().enabled = true;
//
//			}
//			if (Input.GetKeyDown(KeyCode.LeftArrow)){
//
//				picShown -= 1;
//				UnityEditor.AssetDatabase.Refresh();
//
//			}
//			if (Input.GetKeyDown(KeyCode.RightArrow) && picShown <= 10){
//
//				picShown += 1;
//				UnityEditor.AssetDatabase.Refresh();
//
//			}


		//} else {

			picShown  = camControl.picNumber;

		if (Input.GetKey(KeyCode.LeftShift) && !camControl.actuallyTakingPic){

				GetComponent<RawImage>().enabled = true;

			} else {
				GetComponent<RawImage>().enabled = false;

			}

		//}
		
	}
		
}
