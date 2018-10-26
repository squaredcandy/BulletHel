using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Turret", menuName = "Component/Base Turret")]
public class BaseTurret : BaseComponentData
{
	public BaseBulletData projectile;

	public bool bFireProjectile;

	// Time per shot
	public float fireSpeed;

	// Internal counter
	protected float fireTime;

	public override void CreateComponent(Transform spawnpoint)
	{
		base.CreateComponent(spawnpoint);
	}

	public override void UpdateComponent()
	{
		base.UpdateComponent();

		FireProjectile();
	}

	public virtual void FireProjectile()
	{
		fireTime += Time.deltaTime;

		if (!bFireProjectile) return;

		if (fireTime > fireSpeed && Input.GetKey(Statics.inputControl.leftMouse))
		{
			var newProjectile = new GameObject
			{
				name = projectile.name
			};
			var tf = newProjectile.transform;
			tf.position = component.transform.position;
			tf.parent = parent;
			tf.rotation = Quaternion.Euler(projectile.rotation);
			tf.localScale = projectile.scale;

			Instantiate(projectile.bulletPrefab, tf);

			var rb = newProjectile.AddComponent<Rigidbody>();
			rb.useGravity = false;
			rb.velocity = Vector3.up;

			Destroy(newProjectile, 5);
			fireTime = 0f;
		}
	}
}
