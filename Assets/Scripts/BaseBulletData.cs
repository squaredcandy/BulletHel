using UnityEngine;

[CreateAssetMenu(fileName = "Base Bullet", menuName = "Projectile/Base Bullet")]
public class BaseBulletData : ScriptableObject
{
	public new string name;
	public Vector3 rotation;
	public Vector3 scale = Vector3.one / 10f;
	public GameObject bulletPrefab;
}