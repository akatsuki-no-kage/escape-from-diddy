using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable objects/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;        
    public Vector2Int rage = new Vector2Int(5, 4);
    
    [Header("Only UI")]
    public bool isStackable = true;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    weapon,
    equipment,
    consumable
}
public enum ActionType
{
    attack,
    mine,
    consume
}