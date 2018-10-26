using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Player", menuName = "Player/Base Player")]
public class BasePlayerData : ScriptableObject
{
	public new string name;

	public List<BaseShipData> ships;

	public void CreateShip(Transform spawnpoint, int id)
	{
		ships[id].CreateShip(spawnpoint);
	}

	public void UpdateShips()
	{
		foreach(var ship in ships)
		{
			if(ship.created) ship.UpdateComponents();
		}
	}
}