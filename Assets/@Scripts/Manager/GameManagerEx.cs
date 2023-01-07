using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static Define;

[Serializable]
public class GameData
{
	public int Chapter = 1;
	public int Stage = 1;

	public int Coin;
	public int Dia;


	public int ShortRangeWeaponID;
	public int MiddleRangeWeaponID;
	public int LongRangeWeaponID;

	public int SelectedChapter;
	public int SelectedStage;

	public bool BGMOn = true;
	public bool EffectSoundOn = true;

	public int LastStoryID = -1;
}

public class GameManagerEx
{
	GameData _gameData = new GameData();
	public GameData SaveData { get { return _gameData; } set { _gameData = value; } }

	#region Stage
	public int HighestChapter 
	{
		get { return _gameData.Chapter; }
        set { _gameData.Chapter = value; }
	}
	
	public int HighestStage
    {
        get { return _gameData.Stage; }
        set { _gameData.Stage = value; }
    }

	public int SelectedChapter
    {
        get { return _gameData.SelectedChapter; }
        set { _gameData.SelectedChapter = value; }
    }

	public int SelectedStage
    {
        get { return _gameData.SelectedStage; }
        set { _gameData.SelectedStage = value; }
    }

    #endregion

    #region Player

	#endregion


    #region Option
    public bool BGMOn
	{
		get { return _gameData.BGMOn; }
		set { _gameData.BGMOn = value; }
	}

	public bool EffectSoundOn
    {
        get { return _gameData.EffectSoundOn; }
		set { _gameData.EffectSoundOn = value; }
    }
	#endregion


	public event Action<WeaponRangeType> OnChangeWeapon;
	WeaponRangeType _weaponType = WeaponRangeType.Short;
	public WeaponRangeType WeaponType
	{
		get { return _weaponType; }
		set
		{
			_weaponType = value;
			OnChangeWeapon?.Invoke(value);
			//(Managers.UI.SceneUI as UI_GameScene).ChangeSelectedButton(_weaponType);
		}
	}

    WeaponRangeType _disableWeaponRangeType = WeaponRangeType.None;
    public WeaponRangeType DisableWeaponRangeType
    {
        get { return _disableWeaponRangeType; }
        set
        {
            _disableWeaponRangeType = value;

			//(Managers.UI.SceneUI as UI_GameScene)?.DisableWeaponButton(_disableWeaponRangeType);
        }
    }


    public float ZRotation { get; set; }
	public bool IsLoaded = false;

	public void Init()
    {
		_path = Application.persistentDataPath + "/SaveData.json";
		if (LoadGame())
			return;


		IsLoaded = true;

		SaveGame();
    }

	public event Action OnPlayerInput;
	public void PlayerInput()
    {
		OnPlayerInput?.Invoke();
    }

    public event Action OnPlayerAttack;

	public void PlayerAttack()
	{
		OnPlayerAttack?.Invoke();
	}


	void Clear()
	{
		OnChangeWeapon = null;
		OnPlayerAttack = null;
		//OnMonsterDead = null;
		OnPlayerInput = null;
	}





	#region Save&Load
	string _path;

	public void SaveGame()
    {
		string jsonStr = JsonUtility.ToJson(Managers.Game.SaveData);
		File.WriteAllText(_path, jsonStr);
    }

	public bool LoadGame()
    {
		if (File.Exists(_path) == false)
			return false;

        string fileStr = File.ReadAllText(_path);
		GameData data = JsonUtility.FromJson<GameData>(fileStr);
		if (data != null)
			Managers.Game.SaveData = data;

		IsLoaded = true;
		return true;
    }
    #endregion
}