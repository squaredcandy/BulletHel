<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Ship", menuName = "Ship/Base Ship")]
public class BaseShipData : ScriptableObject
{
	public new string name;
	public Vector3 rotation;
	public Vector3 scale = Vector3.one;

	public List<BaseComponentData> shipComponents;

	[HideInInspector] public bool created = false;

	public float speed;

	private GameObject ship;
	private Transform tf;

	public virtual void CreateShip(Transform spawnpoint)
	{
		ship = new GameObject
		{
			name = name
		};
		tf = ship.transform;
		tf.rotation = Quaternion.Euler(rotation);
		tf.localScale = scale;
		tf.parent = spawnpoint;

		foreach (var component in shipComponents)
		{
			component.CreateComponent(tf);
		}
		created = true;
	}

	public virtual void ShipMovement()
	{
		float dt = Time.deltaTime;
		float horizontal = Input.GetAxis(Statics.inputControl.horizontalMovement);
		float vertical = Input.GetAxis(Statics.inputControl.verticalMovement);

		horizontal *= dt * speed;
		vertical *= dt * speed;

		tf.Translate(horizontal, vertical, 0);
	}

	public virtual void UpdateComponents()
	{
		ShipMovement();

		foreach (var component in shipComponents)
		{
			component.UpdateComponent();
		}
	}
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalTransform
{
	[SerializeField] public Vector3 localPosition = Vector3.zero;
	[SerializeField] public Vector3 localRotation = Vector3.zero;
	[SerializeField] public Vector3 localScale = Vector3.one;
}

[System.Serializable]
public class ComponentData
{
	[SerializeField] public LocalTransform transform;
	[SerializeField] public BaseComponentData componentData;
}

[System.Serializable]
public class BaseShipData {

	[SerializeField] public string name;
	[SerializeField] public Vector3 baseRotation = Vector3.zero;
	[SerializeField] public Vector3 baseScale = Vector3.one;
	[SerializeField] public GameObject shipPrefab;
	[SerializeField] public List<ComponentData> componentData;

	BaseShipData()
	{
		baseRotation = Vector3.zero;
		baseScale = Vector3.one;
	}

	public virtual GameObject GenerateShip(Transform spawnParent)
	{
		GameObject ship = GameObject.Instantiate(shipPrefab, spawnParent);
		ship.name = name;
		var tf = ship.transform;
		tf.localPosition = Vector3.zero;
		tf.localRotation = Quaternion.Euler(baseRotation);
		tf.localScale = baseScale;

		foreach(var component in componentData)
		{
			component.componentData.GenerateComponent(tf, component.transform);
		}

		return ship;
	}
}
>>>>>>> Stashed changes
