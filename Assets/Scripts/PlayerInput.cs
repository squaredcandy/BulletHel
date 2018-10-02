using Unity.Entities;

namespace BulletHel.Components
{
	public struct PlayerInput : IComponentData
	{
		public float horizontal;
		public float vertical;
	}
}