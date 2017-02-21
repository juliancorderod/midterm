using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsManager : MonoBehaviour {

	public GameObject lightObj;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < 30; i++){
			Instantiate(lightObj, new Vector3(Random.Range(-20.0f,20.0f), Random.Range(-20.0f,20.0f) , Random.Range(-20.0f,20.0f)), Quaternion.Euler (Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
