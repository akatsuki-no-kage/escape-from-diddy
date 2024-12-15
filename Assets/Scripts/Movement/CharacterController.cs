using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool isAttacking;
    private float lastTimeShoot;
    [SerializeField] private Bullet bulletConfig;
    public virtual void Awake()
    {
        isAttacking = false;
    }

    public void Update()
    {
        HandleDelayTime();
    }

    public void HandleDelayTime()
    {
        lastTimeShoot += Time.deltaTime;
        if (isAttacking && lastTimeShoot > 0.5f)
        {
            lastTimeShoot = 0f;
            isAttacking = false;
            onAttackGunEvent.Invoke(bulletConfig);
        }
    }

    private readonly MoveEvent _moveEvent = new MoveEvent();
    private readonly LookEvent _lookEvent = new LookEvent();
    private readonly AttackMeleeEvent _attackMelee = new AttackMeleeEvent();
    private readonly AttackGunEvent _attackGun = new AttackGunEvent();

    public AttackMeleeEvent onAttackMeleeEvent => _attackMelee;
    public AttackGunEvent onAttackGunEvent => _attackGun;
    public MoveEvent onMoveEvent => _moveEvent;
    public LookEvent onLookEvent => _lookEvent;
}
