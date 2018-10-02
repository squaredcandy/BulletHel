using BulletHel.Components;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour {

	public float speed;
	public Mesh mesh;
	public Material material;

	void Start ()
	{
		var entityManager = World.Active.GetOrCreateManager<EntityManager>();

		var playerEntity = entityManager.CreateEntity(
			ComponentType.Create<Speed>(),
			ComponentType.Create<PlayerInput>(),
			ComponentType.Create<Position>(),
			//ComponentType.Create<TransformMatrix>(),
			ComponentType.Create<MeshInstanceRenderer>()
			);

		entityManager.SetComponentData(playerEntity, new Speed { value = speed });
		entityManager.SetSharedComponentData(playerEntity, new MeshInstanceRenderer
		{
			mesh = mesh,
			material = material
		});
	}
	
}
