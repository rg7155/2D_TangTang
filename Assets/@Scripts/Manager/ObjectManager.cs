using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;
//using DG.Tweening;
using Random = UnityEngine.Random;
using static Define;
using Cinemachine;

public class ObjectManager
{
	PlayerController _player;
	public PlayerController Player { get { return _player; } set { _player = value; } }

	CameraController _camera;
	public CameraController Camera
	{
		get
		{
			if (_camera == null)
				_camera = GameObject.Find("Main Camera").GetComponent<CameraController>();

			return _camera;
		}
	}

	CinemachineVirtualCamera _virtualCamera;
	public CinemachineVirtualCamera virtualCamera
	{
		get
		{
			if (_virtualCamera == null)
				_virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
			return _virtualCamera;
		}
	}


	public ObjectManager()
	{
		Init();
	}

	public void SpawnPlayer(string key, Vector2 pos)
	{
		Managers.Resource.Instantiate(key, callback: (go) =>
		{
			PlayerController pc = go.GetOrAddComponent<PlayerController>();
			pc.SetPos(pos);
			_player = pc;

			Managers.Object.virtualCamera.Follow = _player.transform;
		});
	}
	public void SpawnMonster(string key, Vector2 pos)
	{
		Managers.Resource.Instantiate(key, callback: (go) =>
		{
			MonsterController mc = go.GetOrAddComponent<MonsterController>();
			//mc.SetInfo(monsterData, t);

			mc.SetPos(pos);
		});

	}


	public void Init()
	{

	}

	public void Clear()
	{

	}
}
