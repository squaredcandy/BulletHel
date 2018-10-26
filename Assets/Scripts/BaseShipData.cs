using System.Collections;
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