using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBaseManager : MonoBehaviour
{
    public static CharacterDataBaseManager instance;    // �V���O���g���p�̕ϐ��ł�

    [Header("CharacterDataBase�̃X�N���v�^�u���E�I�u�W�F�N�g")]
    public CharacterDataBase charaDataList;        // public�ł��̂ŁA�C���X�y�N�^�[�ŃA�T�C�����܂�
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

    public CharacterDataBase.CharaData GetCharaData(int charaNo)
    {

        CharacterDataBase.CharaData charaData = new CharacterDataBase.CharaData();
        charaData = charaDataList.charaDatas.Find((x) => x.no == charaNo);
        // �G�̏���EnemyBase�ɖ߂��Ďg����悤�ɂ��܂�
        return charaData;
    }
}
