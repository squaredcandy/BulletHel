using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour {

	public Vector3 forwardVector;
	public float speed;
	protected Rigidbody rb;
	protected Transform tf;

	void Start () {
		rb = GetComponent<Rigidbody>();
		tf = transform;
	}
	
	void Update () {
		rb.MovePosition(transform.position + forwardVector * speed);
	}

	protected virtual void OnTriggerEnter(Collider other)
	{

	}
}