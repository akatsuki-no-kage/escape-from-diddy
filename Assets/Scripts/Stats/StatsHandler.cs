using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class StatsHandler : MonoBehaviour
{

    [SerializeField] private CharacterStats stats;
    private CharacterController characterController;
    public CharacterStats CurrentHealth { get; private set; }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        CurrentHealth = stats.Clone();
        characterController.onDamgeEvent.AddListener(ChangedHealth);
        characterController.onDeathEvent.AddListener(Death);
    }

    private void ChangedHealth(float damage)
    {
        CurrentHealth.maxHealth -= damage;
        Debug.Log(CurrentHealth.maxHealth);
        if (CurrentHealth.maxHealth <= 0)
        {
            characterController.isDead = true;
        }
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
