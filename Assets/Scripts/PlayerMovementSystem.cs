using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

namespace BulletHel.Components
{
	public class PlayerMovementSystem : JobComponentSystem
	{
		private struct PlayerMovementJob : IJobProcessComponentData<Speed, PlayerInput, Position>
		{
			public float deltaTime;

			public void Execute(ref Speed speed, ref PlayerInput input, ref Position position)
			{
				position.Value.x += speed.value * input.horizontal * deltaTime;
				position.Value.y += speed.value * input.vertical * deltaTime;
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			var job = new PlayerMovementJob
			{
				deltaTime = Time.deltaTime
			};
			return job.Schedule(this, inputDeps);
		}
	}
}