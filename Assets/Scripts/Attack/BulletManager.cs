using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public static BulletManager instance;
    private ObjectPool objectPool;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        objectPool = ObjectPool.bulletManager;
    }

    public void CreateEffectDestroyBullet(Vector3 position, Bullet bullet)
    {
        particleSystem.transform.position = position;
        ParticleSystem.EmissionModule em = particleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(bullet.size * 5f)));
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startSpeedMultiplier = bullet.size * 10f;
        particleSystem.Play();
    }

    public void ShootBullet(Vector2 startPos, Vector2 direction, Bullet bulletConfig)
    {
        GameObject bullet = objectPool.GetBullet();
        bullet.transform.position = startPos;
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.InitConfigBullet(bulletConfig,direction,this);
        Debug.Log(startPos);
        bullet.SetActive(true);
    }
}
