using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurretControls : MonoBehaviour {

	public float fireSpeed;
	public Transform spawnPoint;
	public GameObject projectilePrefab;
	protected float fireTime;
	private Transform tf;

	void Start () {
		tf = transform;
		fireTime = 0f;
	}
	
	void Update () {
		fireTime += Time.deltaTime;

		if(Statics.Fire0 && !Statics.EditMode)
		{
			if(fireTime >= fireSpeed)
			{
				fireTime = 0f;
				FireBullet();
			}
		}
	}

	public virtual void FireBullet()
	{
		var projectile = Instantiate(projectilePrefab);
		projectile.transform.position = spawnPoint.position;
		var bullet = projectile.GetComponent<BaseBullet>();
		bullet.forwardVector = tf.up;

		Destroy(projectile, 5);
	}
}
