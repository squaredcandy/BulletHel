using System.Collections;
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
}