﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflyManager : MonoBehaviour {

	public GameObject fireFlyObj;

	public int fireflyNumber;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < fireflyNumber; i++){
			Instantiate(fireFlyObj, new Vector3(Random.Range(-30.00f,30.00f), 
				Random.Range(-10.00f,8.00f) , Random.Range(-30.00f,-10.00f)), Quaternion.identity);
		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
