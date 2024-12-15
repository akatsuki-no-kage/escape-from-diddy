using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private CharacterController characterController;
    private float speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        ApplyMovement(movement);
    }

    private void Start()
    {
        characterController.onMoveEvent.AddListener(OnMove);
    }

    private void OnMove(Vector2 movement)
    {
        this.movement = movement;
    }

    private void ApplyMovement(Vector2 movement)
    {
        rb.velocity = movement * speed;
    }
}

