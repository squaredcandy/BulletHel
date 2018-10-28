<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartPicker : MonoBehaviour
{
	public PlayerData player;
	public new Camera camera;
	public GameObject selectedPart;
	// This is referenced - Any changes will affect the original component
	public ComponentData selectedComponentData;

	public ComponentViewer componentPanel;

	private Vector3 movement;

	public void ResetPlayer()
	{
		selectedPart = null;
		selectedComponentData = null;
		movement = Vector3.zero;
	}

	public bool PartSelected()
	{
		return selectedPart != null && selectedComponentData != null;
	}

	public void ControlComponentViewer()
	{
		// 		showComponentMods = selectedPart != null 
		// 			&& selectedComponentData != null;

		bool showEditPanel = Statics.ComponentEditMode == EditMode.Modify 
			&& PartSelected();

		if (showEditPanel) selectedComponentData.componentData.
				ShowComponentModifications(componentPanel, selectedPart, 
				selectedComponentData);
		componentPanel.gameObject.SetActive(showEditPanel);
	}

	public void UpdateComponentData()
	{
		// Translate
		if(Statics.ComponentTransformMode == TransformMode.Translate)
		{
			var pos = movement * Statics.TranslateSpeed;
			selectedPart.transform.localPosition += pos;
			selectedComponentData.transform.localPosition += pos;
		}
		// Rotate
		else if (Statics.ComponentTransformMode == TransformMode.Rotate)
		{
			var rot = Vector3.forward * movement.x * Statics.RotateSpeed;
			selectedPart.transform.localEulerAngles += rot;
			selectedComponentData.transform.localRotation += rot;
		}
	}

	public void Update()
	{
		// We do the component transform modifications here
		if(Statics.EditMode && Statics.ComponentEditMode == EditMode.Modify &&
			PartSelected())
		{
			if(Statics.TranslationDown)
			{
				Statics.ComponentTransformMode = TransformMode.Translate;
				Debug.Log("Translation Mode");
			}
			else if (Statics.RotationDown)
			{
				Statics.ComponentTransformMode = TransformMode.Rotate;
				Debug.Log("Rotation Mode");
			}

			movement = new Vector3(Statics.HorizontalMovement, 
				Statics.VerticalMovement) * Time.deltaTime;
			
			if(movement.magnitude != 0)
			{
				componentPanel.updateComponentValues = true;
			}
		}

		// We update any values that are changed
		if(componentPanel.updateComponentValues)
		{
			UpdateComponentData();
			componentPanel.updateComponentValues = false;
		}
	}

	public void FixedUpdate()
	{
		bool updateParts = false;

		if(Statics.LeftMouseDown && Statics.EditMode)
		{
			Vector3 mousePos = Input.mousePosition;

			Ray mouseRay = camera.ScreenPointToRay(mousePos);

			if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
			{
				Debug.Log("Hit: " + hitInfo.transform.name);
				selectedPart = hitInfo.transform.gameObject;
				updateParts = true;
			}
		}

		if(updateParts)
		{
			if(selectedPart.transform.IsChildOf(player.currentShip.transform))
			{
				Debug.Log("Selected Part is a child of the current ship, " +
					"looking for the component data");
				UpdatePartData();
			}
			else
			{
				Debug.Log("Selected part is not a child of the current ship");
				selectedComponentData = null;
			}
			ControlComponentViewer();
		}
	}

	public void UpdatePartData()
	{
		BaseShipData shipData = player[player.currentShipIndex];
		foreach(var component in shipData.componentData)
		{
			if (component.componentData.name == selectedPart.name)
			{
				selectedComponentData = component;
				Debug.Log("Found " + selectedPart.name + "'s ComponentData");
				return;
			}
		}
		Debug.Log("Failed to find " + selectedPart.name + "'s ComponentData");
	}
>>>>>>> master
}