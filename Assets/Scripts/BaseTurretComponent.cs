<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Turret", menuName = "Component/Base Turret")]
public class BaseTurretComponent : BaseComponentData {

	public float fireSpeed;
	public GameObject projectilePrefab;

	public override void GenerateComponent(Transform parentTranfrom, 
		LocalTransform localTransform)
	{
		base.GenerateComponent(parentTranfrom, localTransform);
		var turretControls = newComponent.GetComponent<BaseTurretControls>();

		turretControls.fireSpeed = fireSpeed;
		turretControls.projectilePrefab = projectilePrefab;
	}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Turret", menuName = "Component/Base Turret")]
public class BaseTurretComponent : BaseComponentData {

	public float fireSpeed;
	public GameObject projectilePrefab;

	public override void GenerateComponent(Transform parentTranfrom, 
		LocalTransform localTransform)
	{
		base.GenerateComponent(parentTranfrom, localTransform);
		var turretControls = newComponent.GetComponent<BaseTurretControls>();

		turretControls.fireSpeed = fireSpeed;
		turretControls.projectilePrefab = projectilePrefab;
	}

	public override void GenerateSampleComponent(ComponentPreview componentPreview)
	{
		base.GenerateSampleComponent(componentPreview);
		newComponent.GetComponent<BaseTurretControls>().enabled = false;
	}

	public override void ShowComponentModifications(ComponentViewer componentViewer, 
		GameObject part, ComponentData data)
	{
		base.ShowComponentModifications(componentViewer, part, data);

		componentViewer.componentData.text = "Fire Speed: " + (1f / fireSpeed).ToString("F2") +
			" attacks per second";
	}
>>>>>>> master
}