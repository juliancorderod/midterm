using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabScript : MonoBehaviour {

	public float secToAppear;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(!camControl.liftCamTrueFirst){
			if (Time.realtimeSinceStartup >= secToAppear){

				GetComponent<Image>().color += new Color(0,0,0,0.2f * Time.deltaTime);

			}

		}
		if(camControl.liftCamTrueFirst){

			GetComponent<Image>().enabled = false;

		}
	}
}
