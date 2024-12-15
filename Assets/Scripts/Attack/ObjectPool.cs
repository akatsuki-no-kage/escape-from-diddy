using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool bulletManager;
    
    [SerializeField] private List<GameObject> _listBullet;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _bulletCount;

    private void Awake()
    {
        bulletManager = this;
    }

    private void Start()
    {
        _listBullet = new List<GameObject>();
        for (int i = 0; i < _bulletCount; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            _listBullet.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < _listBullet.Count; i++)
        {
            if (!_listBullet[i].activeInHierarchy)
            {
                return _listBullet[i];
            }
        }

        return null;
    }
}
