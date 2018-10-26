using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public Transform spawnParent;
	public BasePlayerData playerData;

	void Start () {
		playerData.CreateShip(spawnParent, 0);
	}

	void Update () {
		playerData.UpdateShips();
	}
}