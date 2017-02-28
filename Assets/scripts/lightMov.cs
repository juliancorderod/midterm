using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMov : MonoBehaviour {

	float speed;

	public float speedMax;
	public float speedMin;

	public float wrapVal;

	Color[] colors;

	int index;

	// Use this for initialization
	void Start () {

		speed = Random.Range(speedMin, speedMax);


		colors = new Color[5];

		colors[0] = new Color((239f/255f), (231f/255f), (201f/255f));
		colors[1] = new Color((255f/255f), (199f/255f), (0f/255f));
		colors[2] = new Color((130f/255f), (102f/255f), (3f/255f));
		colors[3] = new Color((191f/255f), (115f/255f), (15f/255f));
		colors[4] = new Color((99f/255f), (43f/255f), (16f/255f));


		//colorPicked = Random.Range(0,colors.Length);

		GetComponent<Light>().color = colors[Random.Range(0,colors.Length)];

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate( new Vector3(speed*Time.deltaTime,0,0));

		if( transform.position.x >= wrapVal){
			transform.position = new Vector3(-wrapVal, transform.position.y,transform.position.z);
		}
		if( transform.position.y >= wrapVal){
			transform.position = new Vector3(transform.position.x, -wrapVal, transform.position.z);
		}
		if( transform.position.z >= wrapVal){
			transform.position = new Vector3(transform.position.x, transform.position.y, -wrapVal);
		}

		if( transform.position.x <= -wrapVal){
			transform.position = new Vector3(wrapVal, transform.position.y,transform.position.z);
		}
		if( transform.position.y <= -wrapVal){
			transform.position = new Vector3(transform.position.x, wrapVal, transform.position.z);
		}
		if( transform.position.z <= -wrapVal){
			transform.position = new Vector3(transform.position.x, transform.position.y, wrapVal);
		}
		
	}
}
