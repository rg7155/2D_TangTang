using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
	public enum UIEvent
	{
		Click,
		Press
	}

	public enum SceneType
    {
        Unknown,
        GameScene,
		SelectStageScene,
		TitleScene,
	}

    public enum Sound
    {
        Bgm,
		SubBgm,
        Effect,
        Max,
    }

	public enum WeaponRangeType
	{
		None,
		Short,
		Middle,
		Long
	}

    public enum WeaponAttackType
    {
        Melee,
        Range,
        Trap,
    }

    public enum BattleState
	{
		Ready,
		PlayerInput,
		PlayerAttack,
		BossAttack,
		MonsterAttack,
		GameOver,
	}

	public enum CreatureState
	{
		Idle,
		Moving,
		Attack,
		Dead
	}

	public enum KnockbackDirection
	{
		Front,
		Back,
		Clockwise,
		AntiClockwise,
	}


	public const int TILEMAP_SIZE = 40;

}
