using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class GameData {

	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	public int versionNum=0;


	public int coinNum;
	public int diamondNum;

	public string[]testStrs=new string[]{"I","Fuck","you"};


	static GameData instance;

	public static GameData GetInstance()
	{
		if (null != instance) {
			return instance;
		
		}else {
			instance = new GameData ();
		
			//save file exist or not
			string filePath = instance.GetSavePath ();
			if (File.Exists(filePath))
			{
				// If we have a save, we read it.
				instance.ReadGameData();
			}
			else
			{
				// If not we create one with default data.
				instance.SaveGameData();
			}
			return instance;
		}
	}


	public void SaveGameData()
	{
		Debug.Log ("SaveGameData");
		BinaryWriter w = new BinaryWriter(new FileStream(GetSavePath(), FileMode.OpenOrCreate));

		w.Write(versionNum);
		w.Write(coinNum);
		w.Write(diamondNum);
		w.Write(testStrs.Length);

		foreach(string str in testStrs)
		{
			w.Write(str);
		}

		w.Close();
	}

	public string GetSavePath()
	{
		return Application.persistentDataPath + "/save.bin";
	}

	public void ReadGameData()
	{
		BinaryReader r = new BinaryReader(new FileStream(GetSavePath(), FileMode.Open));

		versionNum = r.ReadInt32();
		coinNum= r.ReadInt32();
		diamondNum = r.ReadInt32();

		Debug.Log ("versionNum:"+versionNum);
		Debug.Log ("coinNum:"+coinNum);
		Debug.Log ("diamondNum:"+diamondNum);

		int stringCount = r.ReadInt32();

		for (int i = 0; i < stringCount; ++i)
		{
			Debug.Log ("string:"+r.ReadString());
		}
			
		r.Close();
	}
}




#if UNITY_EDITOR
public class GameDataEditor : Editor
{
	[MenuItem("GameData Debug/Clear Save")]
	static public void ClearSave()
	{
		File.Delete(Application.persistentDataPath + "/save.bin");
	}

	[MenuItem("GameData Debug/Game money")]
	static public void GiveCoins()
	{
		GameData.GetInstance().coinNum += 10;
		GameData.GetInstance().diamondNum += 1000;
		GameData.GetInstance ().SaveGameData ();
	}


}
#endif