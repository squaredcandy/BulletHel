using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public new string name;
	public List<BaseShipData> listOfShips;

	public int currentShipIndex;

	public Transform spawnParent;
	public GameObject currentShip;

	public string filePath;
	protected string filename;
	protected static int saveSlot = 0;

	public BaseShipData this[int val]
	{
		get
		{
			return listOfShips[currentShipIndex];
		}
	}

	void Start () {
		UpdateFilename(0);
		if (listOfShips.Count == 0) currentShipIndex = -1;
		else
		{
			currentShipIndex = 0;
			GenerateShip();
		}
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) // Left Ctrl is bugged
		{
			if (Statics.SaveButtonDown)
				SavePlayer();
			else if (Statics.LoadButtonDown)
				LoadPlayer();
			else if (Input.GetKeyDown(KeyCode.Alpha0)) UpdateFilename(0);
			else if (Input.GetKeyDown(KeyCode.Alpha1)) UpdateFilename(1);
			else if (Input.GetKeyDown(KeyCode.Alpha2)) UpdateFilename(2);
			else if (Input.GetKeyDown(KeyCode.Alpha3)) UpdateFilename(3);
			else if (Input.GetKeyDown(KeyCode.Alpha4)) UpdateFilename(4);
			else if (Input.GetKeyDown(KeyCode.Alpha5)) UpdateFilename(5);
			else if (Input.GetKeyDown(KeyCode.Alpha6)) UpdateFilename(6);
			else if (Input.GetKeyDown(KeyCode.Alpha7)) UpdateFilename(7);
			else if (Input.GetKeyDown(KeyCode.Alpha8)) UpdateFilename(8);
			else if (Input.GetKeyDown(KeyCode.Alpha9)) UpdateFilename(9);
		}
	}

	public virtual void DestroyShip()
	{
		if(currentShip) Destroy(currentShip);
	}

	public virtual void GenerateShip()
	{
		DestroyShip();
		currentShip = listOfShips[currentShipIndex].GenerateShip(spawnParent);
	}

	public void SavePlayer()
	{
		WriteToFile(JsonUtility.ToJson(this, true));
	}

	public void LoadPlayer()
	{
		ReadFromFile();
	}

	protected virtual void WriteToFile(string stringToSave)
	{
		try
		{
			if(!Directory.Exists(filePath))
			{
				Debug.Log("Creating folder " + filePath);
				Directory.CreateDirectory(filePath);
			}
			Debug.Log("Saving Player Data to " + filename);
			if (File.Exists(filename)) Debug.Log("Overriding " + filename);
			File.WriteAllText(filename, stringToSave);
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex);
			Debug.Log("Saving Player Data failed");
			return;
		}
	}

	protected virtual void ReadFromFile()
	{
		try
		{
			if (!File.Exists(filename))
			{
				Debug.Log(filename + " doesn't exist");
				return;
			}
			var str = File.ReadAllText(filename);
			Debug.Log(str);

			DestroyShip();

			JsonUtility.FromJsonOverwrite(str, this);
			GenerateShip();
		}
		catch (System.Exception ex)
		{
			Debug.LogError(ex);
			Debug.Log("Loading Player Data failed");
			return;
		}
	}

	public void UpdateFilename(int val)
	{
		Debug.Log("Saving to slot " + val);
		saveSlot = val;
		filename = filePath + name + saveSlot + ".json";
	}
}
