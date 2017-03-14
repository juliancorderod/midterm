using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireFlyScript : MonoBehaviour {

	public Animator fireflyControl;

	//Animation[] fireflyAnims;

	string[] fireflyAnims;

	// Use this for initialization
	void Start () {

		fireflyAnims = new string[3];

		fireflyAnims[0] = "firefly1";
		fireflyAnims[1] = "firefly2";
		fireflyAnims[2] = "firefly3";
//		fireflyAnims[3] = "firefly4";
//		fireflyAnims[4] = "firefly5";


		fireflyControl.Play(fireflyAnims[Random.Range(0,fireflyAnims.Length)]);

		
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);

		//transform.eulerAngles += new Vector3(0, 1* Time.deltaTime, 0);
		
	}
}
