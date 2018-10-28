<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShipControls : MonoBehaviour {

	public float speed;
	private Transform tf;

	void Start () {
		tf = transform;
	}
	
	void Update () {

		if(!Statics.EditMode)
		{
			float vertical = Statics.VerticalMovement;
			float horizontal = Statics.HorizontalMovement;

			tf.Translate(horizontal * speed, vertical * speed, 0);
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if(!Statics.IsPlayerProjectile(ref other))
		{
			Debug.Log("Entered Trigger with " + other.gameObject.name);
		}
	}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShipControls : MonoBehaviour {

	public float speed;
	private Transform tf;

	void Start () {
		tf = transform;
	}
	
	void Update () {

		if(!Statics.EditMode)
		{
			float vertical = Statics.VerticalMovement;
			float horizontal = Statics.HorizontalMovement;

			tf.Translate(horizontal * speed, vertical * speed, 0);
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if(!Statics.IsPlayerProjectile(ref other))
		{
			Debug.Log("Entered Trigger with " + other.gameObject.name);
		}
	}
>>>>>>> master
}