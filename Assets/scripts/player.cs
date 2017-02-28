using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	CharacterController control;

	// Use this for initialization
	void Start () {

		control = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		control.Move(transform.forward * Time.deltaTime * vertical * 5f);
		control.Move(transform.right * Time.deltaTime * horizontal * 5f);
		transform.Rotate(0,Input.GetAxis("Mouse X") * Time.deltaTime * camControl.rotationVal,0);

		
	}
}
