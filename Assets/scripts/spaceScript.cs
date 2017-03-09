using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceScript : MonoBehaviour {

	public float secToAppear;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(camControl.liftCamTrueFirst){
			
			StartCoroutine (spaceAppear());

		}
		if(!camControl.liftCamTrueFirst){

			GetComponent<Image>().enabled = false;

		}
		if(camControl.takingFirstPic){

			GetComponent<Image>().enabled = false;

		}
	}

	public IEnumerator spaceAppear(){


		//if (Time.realtimeSinceStartup >= secToAppear){

			GetComponent<Image>().enabled = true;

			yield return new WaitForSeconds(secToAppear);

			GetComponent<Image>().color += new Color(0,0,0,0.2f * Time.deltaTime);

		//}

	}
}