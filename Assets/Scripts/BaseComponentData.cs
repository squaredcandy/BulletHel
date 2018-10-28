using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Component", menuName = "Component/Base Component")]
public class BaseComponentData : ScriptableObject {

	public new string name;
	public GameObject componentPrefab;

	public float sampleRotationSpeed = 10f;
	public float sampleScale = 100f;

	protected GameObject newComponent;

	public virtual void GenerateComponent(Transform parentTranform,
		LocalTransform localTransform)
	{
		newComponent = Instantiate(componentPrefab, parentTranform);
		newComponent.name = name;
		var tf = newComponent.transform;
		tf.localPosition = localTransform.localPosition;
		tf.localRotation = Quaternion.Euler(localTransform.localRotation);
		tf.localScale = localTransform.localScale;
	}

	public virtual void GenerateSampleComponent(ComponentPreview componentPreview)
	{
		newComponent = Instantiate(componentPrefab, componentPreview.spawnParent);
		newComponent.name = name;
		newComponent.transform.localScale *= sampleScale;

		// Disable the collider
		var collider = newComponent.GetComponent<Collider>();
		if(collider) collider.enabled = false;

		newComponent.AddComponent<SampleRotator>().rotationSpeed = sampleRotationSpeed;

		componentPreview.componentNameText.text = name;
	}

	public virtual void ShowComponentModifications(ComponentViewer componentViewer,
		GameObject part, ComponentData data)
	{
		componentViewer.componentName.text = data.componentData.name;
		componentViewer.componentData.text = "";
	}
}
