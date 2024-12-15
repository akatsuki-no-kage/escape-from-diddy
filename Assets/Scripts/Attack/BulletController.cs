using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private BulletManager bulletManager;
    [SerializeField] Bullet bulletConfig;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private List<LayerMask> _layerMask;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float currentDuration;
    private Vector2 direction;
    private bool isShoot;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    private void Update()
    {
        if (!isShoot)
        {
            return;
        }
        currentDuration += Time.deltaTime;
        if (currentDuration > bulletConfig.duration)
        {
            DestroyBullet(transform.position, false);
        }
        _rigidbody2D.velocity = direction * bulletConfig.speed;
    }

    public void InitConfigBullet(Bullet bulletConfig, Vector2 direction, BulletManager bulletManager)
    {
        this.bulletManager = bulletManager;
        this.bulletConfig = bulletConfig;
        this.direction = direction;
        UpdateSpriteBullet();
        currentDuration = 0f;
        
        isShoot = true;
        
    }

    public void UpdateSpriteBullet()
    {
        transform.localScale = Vector3.one * bulletConfig.size;
        spriteRenderer.color = bulletConfig.colorBullet;
    }

    public void DestroyBullet(Vector3 pos, bool animate)
    {
        if (animate)
        {
            bulletManager.CreateEffectDestroyBullet(pos,bulletConfig);
        }
        gameObject.SetActive(false);
        
    }
}
