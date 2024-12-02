using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private readonly MoveEvent _moveEvent = new MoveEvent();
    private readonly LookEvent _lookEvent = new LookEvent();
    
    public MoveEvent onMoveEvent => _moveEvent;
    public LookEvent onLookEvent => _lookEvent;
}
