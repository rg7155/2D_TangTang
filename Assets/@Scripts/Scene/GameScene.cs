using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using static Define;
using System.Linq;

public class GameScene : BaseScene
{
	class MissionData
	{
		public int currentCount;
		public int clearCount;
	}

	Dictionary<int, MissionData> _stageMissionData;
	int _remainingTurn;

	BattleState _state { get; set; } = BattleState.Ready;
	public BattleState State
	{
		get { return _state; }
		set
		{
			_state = value;
		}
	}

    [SerializeField]
    SpriteRenderer _bg;


	IEnumerator _currentSequenceCoroutine;
	bool _gameStart = false;


	protected override bool Init()
	{
		if (base.Init() == false)
			return false;

		SceneType = Define.SceneType.GameScene;


		StartCoroutine(CoWaitLoad());

		return true;
	}

	IEnumerator CoWaitLoad()
	{
		//while (Managers.Data.Loaded() == false)
		//	yield return null;


		Managers.Object.SpawnPlayer("Player", Vector2.zero);

		//Managers.Sound.Play(Sound.Bgm, "Sound_Battle1");

		yield return new WaitForSeconds(0.5f);
		SpawnMonsterAtRandomPos();
		//yield return StartCoroutine(SpawnMonsterAtRandomPos);
		_gameStart = true;
	}

	
	void Update()
	{
		if (!_gameStart)
			return;

	}

	void SpawnMonsterAtRandomPos()
    {
		//초기 플레이어 위치는 0,0이라고 가정
		for (int i = 0; i < 10; ++i)
		{
			var pos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
			Managers.Object.SpawnMonster("Monster0", pos * TILEMAP_SIZE);
		}

	}


	#region EventHandler


	void OnEnable()
	{
		if (Managers.Game == null)
			return;

		//Managers.Game.OnChangeWeapon -= OnChangeWeapon;
		//Managers.Game.OnChangeWeapon += OnChangeWeapon;
		//Managers.Game.OnPlayerAttack -= OnPlayerAttack;
		//Managers.Game.OnPlayerAttack += OnPlayerAttack;
		//Managers.Game.OnMonsterDead -= OnMonsterDead;
		//Managers.Game.OnMonsterDead += OnMonsterDead;
	}

	void OnDisable()
	{
		if (Managers.Game == null)
			return;

		//Managers.Game.OnChangeWeapon -= OnChangeWeapon;
		//Managers.Game.OnPlayerAttack -= OnPlayerAttack;
		//Managers.Game.OnMonsterDead -= OnMonsterDead;
		//Managers.Object.Player = null;
	}
	#endregion
}
