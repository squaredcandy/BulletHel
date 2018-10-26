using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
	public static InputControls inputControl { get; private set; }

	public void Start()
	{
		inputControl = FindObjectOfType<InputControls>();
	}
}