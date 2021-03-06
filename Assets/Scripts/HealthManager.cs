﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // Config
    int maxHealth;

    // Initialize variables
    private int currentHealth;
    Animator anim;

    // String const
    private const string WILL_DIE_TRIGGER = "willDieTrigger";
    private const string WILL_DIE = "willDie";
    private const string PLAYERHP = "PlayerHP";
    private const string ENEMYHP = "EnemyHP";

    private void Awake()
    {
        if (this.CompareTag("Player"))
        {
            maxHealth = PlayerPrefs.GetInt(PLAYERHP);
        }
        if (this.CompareTag("Enemy"))
        {
            maxHealth = PlayerPrefs.GetInt(ENEMYHP);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            anim.SetBool(WILL_DIE, true);
            anim.SetTrigger(WILL_DIE_TRIGGER);
        }
    }

    public void DissapearAttacker()
    {     
        Destroy(gameObject);
    }

    public float GetCurrentHealth() { return currentHealth; }
    public float GetMaxHealth() { return maxHealth; }

    public void UpDateMaxHealth(int newMaxHealth){maxHealth = newMaxHealth; currentHealth = maxHealth;}
    public void HealCharacter(int healedAmount) 
    { 
        currentHealth += healedAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}
