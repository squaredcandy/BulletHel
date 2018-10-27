using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
	private static InputControls input;

	public void Start()
	{
		input = FindObjectOfType<InputControls>();
	}

	public void SetEditMode(bool val)
	{
		EditMode = val;
		Debug.Log("Edit Mode is " + (EditMode ? "On" : "Off"));
	}

	public static bool EditMode { get; set; }

	public static float VerticalMovement { get => Input.GetAxis(input.verticalMovement); }
	public static float HorizontalMovement { get => Input.GetAxis(input.horizontalMovement); }

	public static bool Fire0 { get => Input.GetKey(input.Fire0); }


	public static bool LeftMouse { get => Input.GetKey(input.leftMouse); }
	public static bool LeftMouseDown { get => Input.GetKeyDown(input.leftMouse); }
	public static bool LeftMouseUp { get => Input.GetKeyUp(input.leftMouse); }

	public static bool RightMouse { get => Input.GetKey(input.rightMouse); }
	public static bool RightMouseDown { get => Input.GetKeyDown(input.rightMouse); }
	public static bool RightMouseUp { get => Input.GetKeyUp(input.rightMouse); }

	public static bool SaveButtonDown { get => Input.GetKeyDown(input.saveButton); }
	public static bool LoadButtonDown { get => Input.GetKeyDown(input.loadButton); }

	public static bool IsPlayerProjectile(ref Collider c) { return c.CompareTag("PlayerProjectile"); }
	public static bool IsEnemyProjectile(ref Collider c) { return c.CompareTag("EnemyProjectile"); }
}