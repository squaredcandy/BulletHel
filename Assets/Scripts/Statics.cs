using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Statics : MonoBehaviour {

	public static InputControls inputControl { get; private set; }
	public static EntityManager entityManager { get; private set; }
	public static Entity playerEntity { get; set; }
	private static EntitySpawner entitySpawner { get; set; }

	public void Start()
	{
		entityManager = World.Active.GetExistingManager<EntityManager>();
		entitySpawner = FindObjectOfType<EntitySpawner>();
		inputControl = FindObjectOfType<InputControls>();

		entitySpawner.entityManager = entityManager;
		entitySpawner.CreatePlayer();
	}

	public static bool PlayerExists()
	{
		return entityManager.Exists(playerEntity);
	}
}
