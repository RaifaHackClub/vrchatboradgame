﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Swordsman : UdonSharpBehaviour
{
    public int currentHealth;
    public int attack;
    public int defense;
    public double attackSpeed;

    void Start()
    {
        currentHealth = 120;
        attack = 15;
        defense = 10;
        attackSpeed = 2;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        // Add additional logic like checking for death here
    }

    public void Attack(Swordsman target)
    {
        int damage = attack - target.defense;
        if (damage < 0) damage = 0;
        target.TakeDamage(damage);
    }

    public void UpgradeHealth(int value)
    {
        currentHealth += value;
    }

    public void UpgradeAttack(int value)
    {
        attack += value;
    }

    public void UpgradeDefense(int value)
    {
        defense += value;
    }

    public void UpgradeAttackSpeed(int value)
    {
        attackSpeed += value;
    }
}
