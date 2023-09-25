using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletCtrl : UbhBulletSimpleSprite2d, IBullet
{

    [SerializeField]
    private int _bulletAtk;

    public int BulletAtk => _bulletAtk;

}
