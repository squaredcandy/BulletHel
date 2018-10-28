<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
	public static InputControls inputControl { get; private set; }

	public void Start()
	{
		inputControl = FindObjectOfType<InputControls>();
	}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransformMode
{
	Translate = 0,
	Rotate = 1
}

public enum EditMode
{
	None = 0,
	Modify = 1,
	Add = 2,
}


public class Statics : MonoBehaviour
{
	private static InputControls input;

	public float translateSpeed;
	public float rotateSpeed;

	public void Start()
	{
		input = FindObjectOfType<InputControls>();
		TranslateSpeed = translateSpeed;
		RotateSpeed = rotateSpeed;
		ComponentTransformMode = TransformMode.Translate;
		ComponentEditMode = global::EditMode.Modify;
	}

	public void SetEditMode(bool val)
	{
		EditMode = val;
		Debug.Log("Edit Mode is " + (EditMode ? "On" : "Off"));
	}

	public static TransformMode ComponentTransformMode { get; set; }
	public static float TranslateSpeed { get; set; }
	public static float RotateSpeed { get; set; }

	public static EditMode ComponentEditMode { get; set; }

	public static float VerticalMovement { get => Input.GetAxis(input.verticalMovement); }
	public static float HorizontalMovement { get => Input.GetAxis(input.horizontalMovement); }

	public static bool Fire0 { get => Input.GetKey(input.Fire0); }

	public static bool EditMode { get; set; }

	public static bool LeftMouse { get => Input.GetKey(input.leftMouse); }
	public static bool LeftMouseDown { get => Input.GetKeyDown(input.leftMouse); }
	public static bool LeftMouseUp { get => Input.GetKeyUp(input.leftMouse); }

	public static bool RightMouse { get => Input.GetKey(input.rightMouse); }
	public static bool RightMouseDown { get => Input.GetKeyDown(input.rightMouse); }
	public static bool RightMouseUp { get => Input.GetKeyUp(input.rightMouse); }

	public static bool SaveButtonDown { get => Input.GetKeyDown(input.saveButton); }
	public static bool LoadButtonDown { get => Input.GetKeyDown(input.loadButton); }


	public static bool TranslationDown { get => Input.GetKeyDown(input.translationButton); }
	public static bool RotationDown { get => Input.GetKeyDown(input.rotationButton); }
	public static bool ScaleDown { get => Input.GetKeyDown(input.scaleButton); }

	public static bool UpDown { get => Input.GetKeyDown(input.upButton); }
	public static bool DownDown { get => Input.GetKeyDown(input.downButton); }
	public static bool LeftDown { get => Input.GetKeyDown(input.leftButton); }
	public static bool RightDown { get => Input.GetKeyDown(input.rightButton); }


	public static bool IsPlayerProjectile(ref Collider c) { return c.CompareTag("PlayerProjectile"); }
	public static bool IsEnemyProjectile(ref Collider c) { return c.CompareTag("EnemyProjectile"); }
>>>>>>> Stashed changes
}