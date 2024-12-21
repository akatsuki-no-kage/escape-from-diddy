using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{ 
    private ObjectPoolItem objectPoolItem;
    public static BombManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        objectPoolItem = ObjectPoolItem.ObjectPoolItemInstance;
    }
    public void ThrowBomb(Vector2 startPos, BombConfig bombConfig, Vector2 direction)
    {
        GameObject bomGameObject = objectPoolItem.GetObject();
        bomGameObject.transform.position = startPos;
        BombController bombController = bomGameObject.GetComponent<BombController>(); 
        bombController.InitBomb(bombConfig, direction);
        bomGameObject.SetActive(true);
    }
}
