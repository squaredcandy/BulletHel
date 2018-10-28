using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentPicker : MonoBehaviour {

	public ShipPartPicker shipPartPicker;
	public ComponentList listOfComponents;

	public Transform scrollViewContent;
	public GameObject previewPrefab;

	private Transform tf;

	void Start ()
	{
		LocalTransform local = new LocalTransform();
		tf = transform;
		foreach(var component in listOfComponents.availableComponents)
		{
			var preview = Instantiate(previewPrefab, scrollViewContent);
			component.GenerateSampleComponent(preview.GetComponent<ComponentPreview>());
		}
	}
	
	void Update () {
		
	}
}
