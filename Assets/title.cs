using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title : MonoBehaviour {

	public float secToAppear;

	public GameObject title2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.realtimeSinceStartup >= secToAppear){

			StartCoroutine(fadeTitle());

		}

		Debug.Log(GetComponent<Text>().color.a);

//		if (Input.GetKeyDown(KeyCode.Tab)){
//
//
//
//		}
		
	}

	public IEnumerator fadeTitle(){

		if (GetComponent<Text>().color.a <= 1){
			GetComponent<Text>().color += new Color(0,0,0,0.2f * Time.deltaTime);
			title2.GetComponent<Text>().color += new Color(0,0,0,0.2f * Time.deltaTime);
		}



		yield return new WaitForSeconds(10f);

		GetComponent<Text>().color -= new Color(0,0,0,0.4f * Time.deltaTime);
		title2.GetComponent<Text>().color -= new Color(0,0,0,0.4f * Time.deltaTime);

	}
}
