using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShipPartPicker : MonoBehaviour
{
	public GameObject selectedPart;
	public new Camera camera;

	public void FixedUpdate()
	{
		if(Statics.LeftMouseDown && Statics.EditMode)
		{
			Vector3 mousePos = Input.mousePosition;

			Ray mouseRay = camera.ScreenPointToRay(mousePos);

			if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
			{
				Debug.Log("Hit: " + hitInfo.transform.name);
				selectedPart = hitInfo.transform.gameObject;
			}
		}
	}
}