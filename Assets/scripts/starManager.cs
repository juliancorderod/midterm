using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starManager : MonoBehaviour {

	public GameObject starObj;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < 100; i++){
			Instantiate(starObj, new Vector3(Random.Range(-500.0f,500.0f), 300 , Random.Range(-500.0f,500.0f)), Quaternion.identity);//.Euler (Random.Range(0,360),Random.Range(0,360),Random.Range(0,360)));
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
