using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Mage : UdonSharpBehaviour
{
    public int health;
    public int damage;
    public int range;

    void Start()
    {
        health = 8;
        damage = 3;
        range = 2;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        // Add additional logic like checking for death here
    }

    public void Attack(Mage target)
    {
        int damage = this.damage - target.defense;
        if (damage < 0) damage = 0;
        target.TakeDamage(damage);
    }
}
