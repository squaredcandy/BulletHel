using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace BulletHel.Components
{
	public class PlayerInputSystem : JobComponentSystem
	{
		private struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
		{
			public float horizontal;
			public float vertical;

			public void Execute(ref PlayerInput input)
			{
				input.horizontal = horizontal;
				input.vertical = vertical;
			}
		}

		protected override JobHandle OnUpdate(JobHandle inputDeps)
		{
			var job = new PlayerInputJob
			{
				horizontal = Input.GetAxis("Horizontal"),
				vertical = Input.GetAxis("Vertical")
			};
			return job.Schedule(this, inputDeps);
		}
	}
}

