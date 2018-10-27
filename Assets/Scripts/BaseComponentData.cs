using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Component", menuName = "Component/Base Component")]
public class BaseComponentData : ScriptableObject {

	public new string name;
	public GameObject componentPrefab;

	protected GameObject newComponent;

	public virtual void GenerateComponent(Transform parentTranfrom,
		LocalTransform localTransform)
	{
		newComponent = Instantiate(componentPrefab, parentTranfrom);
		newComponent.name = name;
		var tf = newComponent.transform;
		tf.localPosition = localTransform.localPosition;
		tf.localRotation = Quaternion.Euler(localTransform.localRotation);
		tf.localScale = localTransform.localScale;
	}
}
