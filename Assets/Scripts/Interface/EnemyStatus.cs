using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStatus 
{

    [SerializeField]
    private int _maxHP;

    public int HP { get; set; }

    [SerializeField]
    private int _attack;

    public int Attack => _attack;

    public void Initialize()
    {
        HP = _maxHP;
    }

    public bool IsDead()
    {
        return HP <= 0;
    }
}
