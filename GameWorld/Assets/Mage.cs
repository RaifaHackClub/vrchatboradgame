using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Mage : UdonSharpBehaviour
{
    public int currentHealth;
    public int attack;
    public int defense;
    public double attackSpeed;

    void Start()
    {
        currentHealth = 60;
        attack = 25;
        defense = 3;
        attackSpeed = 1.5;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        // Add additional logic like checking for death here
    }

    public void Attack(Mage target)
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
