using BulletHel.Components;
using Sirenix.OdinInspector;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : SerializedMonoBehaviour {

	[HideInInspector] public EntityManager entityManager;

	public float speed;
	public Mesh mesh;
	public Material material;

	public void CreatePlayer()
	{
		if (Statics.PlayerExists()) return;
		Statics.playerEntity = entityManager.CreateEntity(
			ComponentType.Create<Speed>(),
			ComponentType.Create<PlayerInput>(),
			ComponentType.Create<Position>(),
			ComponentType.Create<MeshInstanceRenderer>()
		);

		entityManager.SetComponentData(Statics.playerEntity, 
			new Speed { value = speed });
		entityManager.SetSharedComponentData(Statics.playerEntity, 
			new MeshInstanceRenderer
		{
			mesh = mesh,
			material = material
		});
	}

	public Entity CreateEntity()
	{
		return entityManager.CreateEntity();
	}
}
