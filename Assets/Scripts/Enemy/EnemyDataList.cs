using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]
public class EnemyDataList : ScriptableObject
{

	// �G�̏��(EnemyData)���܂Ƃ߂����X�g
	public List<EnemyData> enemyDatas = new List<EnemyData>();

	/// <summary>
	/// �G�̏��(1�̂��̏��)
	/// </summary>
	[Serializable]
	public class EnemyData
	{
		public string enemyName;
		[Header("�G�i���o�[")]
		public int no;
		[Header("�̗�")]
		public int maxHp;
		[Header("�h���b�v�A�C�e��")]
		public int[] dropItemNos;
		[Header("�|�������ɖႦ��|�C���g")]
		public int scorePoint;
	}

	
}
