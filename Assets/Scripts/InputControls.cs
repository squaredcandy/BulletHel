using UnityEngine;

public class InputControls : MonoBehaviour {

	public string horizontalMovement = "Horizontal";
	public string verticalMovement = "Vertical";

	// Debug Fire Key
	public KeyCode Fire0 = KeyCode.Space;

	// Standard Left / Right click
	public KeyCode leftMouse = KeyCode.Mouse0;
	public KeyCode rightMouse = KeyCode.Mouse1;

	// Save / Load ship config
	public KeyCode saveButton = KeyCode.S;
	public KeyCode loadButton = KeyCode.D;


	// Ship part Controls
	public KeyCode translationButton = KeyCode.Q;
	public KeyCode rotationButton = KeyCode.W;
	public KeyCode scaleButton = KeyCode.E;

	public KeyCode upButton = KeyCode.UpArrow;
	public KeyCode downButton = KeyCode.DownArrow;
	public KeyCode leftButton = KeyCode.LeftArrow;
	public KeyCode rightButton = KeyCode.RightArrow;
}