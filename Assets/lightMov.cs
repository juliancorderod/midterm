using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMov : MonoBehaviour {

	float speed;

	public float speedMax;
	public float speedMin;

	// Use this for initialization
	void Start () {

		speed = Random.Range(speedMin, speedMax);

		GetComponent<Light>().color = new Color(Random.Range(0.00f,1.00f),Random.Range(0.00f,1.00f),Random.Range(0.00f,1.00f));

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate( new Vector3(speed*Time.deltaTime,0,0));
		
	}
}
