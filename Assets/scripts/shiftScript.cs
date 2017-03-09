using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shiftScript : MonoBehaviour {

	public float secToAppear;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		Debug.Log(showPic.picOn);

		if(camControl.takenFirstPic){

			StartCoroutine (shiftAppear());

		}
		if(!camControl.takenFirstPic){

			GetComponent<Image>().enabled = false;

		}
//		if(camControl.takingFirstPic){
//
//			GetComponent<Image>().enabled = false;
//
//		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){

			camControl.takenFirstPic = false;

			GetComponent<Image>().enabled = false;

		}
	}

	public IEnumerator shiftAppear(){


		//if (Time.realtimeSinceStartup >= secToAppear){

		GetComponent<Image>().enabled = true;

		yield return new WaitForSeconds(secToAppear);

		GetComponent<Image>().color += new Color(0,0,0,0.2f * Time.deltaTime);

		//}

	}
}