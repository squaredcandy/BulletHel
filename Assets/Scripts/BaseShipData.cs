using System.Collections;
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
