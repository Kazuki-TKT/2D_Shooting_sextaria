using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDataBaseManager : MonoBehaviour
{
    public static EnemyDataBaseManager instance;    // �V���O���g���p�̕ϐ��ł�

    [Header("EnemyDataList�̃X�N���v�^�u���E�I�u�W�F�N�g")]
    public EnemyDataList enemyDataList;        // public�ł��̂ŁA�C���X�y�N�^�[�ŃA�T�C�����܂�

    [Header("��������A�C�e���̃v���t�@�u")]
    public GameObject[] dropItemPrefabs;       // EnemyBase�ɌʂŎ������Ă����A�C�e���̃v���t�@�u����������ŏW�񂵂Ĉ����悤�ɂ��܂�(�o�^�⏈�����y�ɂȂ�܂�) 

    //[Header("��������e���̃v���t�@�u")]
    //public GameObject[] useEnemyBullet;
    void Awake()
    {
        // ���̃Q�[���I�u�W�F�N�g���V���O���g���ɂ��A���A�V�[���J�ڂ��Ă��j������Ȃ��悤�ɂ��܂�
        if (instance == null)
        {
           
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �G�̃f�[�^�x�[�X��G�̔ԍ��Ō������A�G�̏��(EnemyData)��߂�
    /// </summary>
    /// <param name="enemyNo">�G�̔ԍ�</param>
    /// <returns></returns>
    public EnemyDataList.EnemyData GetEnemyData(int enemyNo)
    {

        //////////////////* �@���A�̂����ꂩ�̏����Ō����ł��܂��B�ǂ��炩���L�ڂ��Ă��������B  */////////////////////

        // �@Find�Ō�������ꍇ(using System���K�v�ɂȂ�܂�)

        // EnemyData�����������ăC���X���^���X����(�g�p�ł����Ԃɂ���)
        EnemyDataList.EnemyData enemyData = new EnemyDataList.EnemyData();

        // enemyNo���g����enemyDatas(List)���������A�ΏۂƂȂ����G�̏���enemyData�֑������
        enemyData = enemyDataList.enemyDatas.Find((x) => x.no == enemyNo);

        // �G�̏���EnemyBase�ɖ߂��Ďg����悤�ɂ��܂�
        return enemyData;

        ///////////////////////////////////////////////////

        // �Aforeach�Ō�������ꍇ
        // enemyDatas�̏���1����data�ϐ��Ɏ��o���A���Ԃ�enemyNo�Əƍ����܂�
        //foreach (EnemyDataList.EnemyData data in enemyDataList.enemyDatas)
        //{
        //    // ���X�g�ɓo�^����Ă���G�̔ԍ��Əƍ����Ă���G�̔ԍ��Ƃ����v������A���ꂪ����g���G�̏��ɂȂ�܂�
        //    if (data.no == enemyNo)
        //    {
        //        // �G�̏���EnemyBase�ɖ߂��Ďg����悤�ɂ��܂�
        //        return data;
        //    }
        //}
        //return null;
    }

    /// <summary>
    /// �h���b�v����A�C�e���̔ԍ��Ŕz���index����肵�A�A�C�e���v���t�@�u�̏��(GameObject)���擾���Ė߂�
    /// </summary>
    /// <param name="itemNo">�h���b�v����A�C�e���̔ԍ�</param>
    /// <returns></returns>
    public GameObject GetDropItemPrefabDate(int itemNo)
    {
        return dropItemPrefabs[itemNo];
    }

    //public GameObject UseEnemyBulletPrefabData(int bulletNo)
    //{
    //    return useEnemyBullet[bulletNo];
    //}
}
