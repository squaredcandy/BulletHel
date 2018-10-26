using UnityEngine;

public class BaseComponentData : ScriptableObject
{
	public new string name;
	public GameObject meshPrefab;

	protected GameObject component;
	protected Transform parent;

	public virtual void CreateComponent(Transform parent)
	{
		component = new GameObject
		{
			name = name
		};
		var tf = component.transform;
		tf.parent = parent;

		Instantiate(meshPrefab, tf);
	}

	public virtual void UpdateComponent()
	{

	}
}