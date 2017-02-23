using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carScript : MonoBehaviour {

	public float startPosX;
	public float endPosX;
	public float startPosY;
	public float endPosY;
	public float startPosZ;
	public float endPosZ;

	float lerpCarMov;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(Mathf.Lerp(startPosX,endPosX,lerpCarMov), Mathf.Lerp(startPosY,endPosY,lerpCarMov), Mathf.Lerp(startPosZ,endPosZ,lerpCarMov));

		lerpCarMov += 0.05f * Time.deltaTime;

		if (lerpCarMov >= 1){

			lerpCarMov = 0;

		}
		
	}
}
