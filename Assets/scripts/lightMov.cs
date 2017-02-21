using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMov : MonoBehaviour {

	float speed;

	public float speedMax;
	public float speedMin;

	Color[] colors;

	int index;

	// Use this for initialization
	void Start () {

		speed = Random.Range(speedMin, speedMax);


		colors = new Color[5];

		colors[0] = Color.blue;
		colors[1] = Color.red;
		colors[2] = Color.green;
		colors[3] = Color.yellow;
		colors[4] = Color.magenta;


		//colorPicked = Random.Range(0,colors.Length);

		GetComponent<Light>().color = colors[Random.Range(0,colors.Length)];

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate( new Vector3(speed*Time.deltaTime,0,0));


		
	}
}
