using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRotator : MonoBehaviour {

	public float rotationSpeed;
	protected Transform tf;

	void Start () {
		tf = transform;
	}
	
	void FixedUpdate () {
		tf.localEulerAngles += Vector3.up * rotationSpeed * Time.fixedDeltaTime;
	}
}
