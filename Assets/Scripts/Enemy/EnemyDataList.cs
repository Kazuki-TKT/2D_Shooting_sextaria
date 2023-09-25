using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class EnemyDataList : ScriptableObject
{

	// 敵の情報(EnemyData)をまとめたリスト
	public List<EnemyData> enemyDatas = new List<EnemyData>();

	/// <summary>
	/// 敵の情報(1体ずつの情報)
	/// </summary>
	[Serializable]
	public class EnemyData
	{
		public string enemyName;
		[Header("敵ナンバー")]
		public int no;
		[Header("体力")]
		public int maxHp;
		[Header("ドロップアイテム")]
		public int[] dropItemNos;
		[Header("倒した時に貰えるポイント")]
		public int scorePoint;
	}

	
}
