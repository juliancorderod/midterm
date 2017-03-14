using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDelay : MonoBehaviour {

	public float secToAppear;

	public GameObject carMesh;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.realtimeSinceStartup >= secToAppear){



			GetComponent<Animation>().Play();

			carMesh.SetActive(true);

		} else {

			carMesh.SetActive(false);
		}
		
	}
}
