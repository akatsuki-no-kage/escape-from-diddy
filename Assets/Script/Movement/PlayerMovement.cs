using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement = Vector2.zero;
    private PlayerController playerController;
    private float speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        ApplyMovement(movement);
    }

    private void Start()
    {
        playerController.onMoveEvent.AddListener(OnMove);
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

