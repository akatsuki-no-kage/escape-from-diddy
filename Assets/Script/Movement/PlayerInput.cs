using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : PlayerController
{
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    

    public void OnMovement(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        onMoveEvent.Invoke(direction);
        
    }
}
