using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create CharacterData")]
public class CharacterDataBase : ScriptableObject
{
	// 敵の情報(EnemyData)をまとめたリスト
	public List<CharaData> charaDatas = new List<CharaData>();

	/// <summary>
	/// 敵の情報(1体ずつの情報)
	/// </summary>
	[Serializable]
	public class CharaData
	{
		public string charaName;
		[Header("キャラナンバー")]
		public int no;
		[Header("プロフィール")]
		[TextArea]
		public string profileText;
		[Header("服有画像")]
		public Sprite[] charaSprites;
		[Header("裸画像")]
		public Sprite[] charaSprites_Hadaka;
        [Header("Hサムネ")]
        public Sprite[] Hthumneil;
        [Header("FlouwchartMessage")]
        public String[] message;
        [Header("HButtonNum")]
        public int[] storyNum;
    }
}
