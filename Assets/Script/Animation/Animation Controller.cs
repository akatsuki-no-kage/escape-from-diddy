using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private readonly int isRunning = Animator.StringToHash("isRunning");
    private readonly int isHurt = Animator.StringToHash("isHurt");
    private PlayerController player;
    [SerializeField] private ParticleSystem particleSystem;
    private bool createDust = true;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        player.onMoveEvent.AddListener(Move);
    }

    private void Move(Vector2 movement)
    {
        animator.SetBool(isRunning, movement.magnitude > 0.3f);
    }

    private void Hurt()
    {
        animator.SetBool(isHurt, true);
    }

    private void Dust()
    {
        if (createDust)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }
}
