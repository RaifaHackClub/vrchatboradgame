using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Archer : UdonSharpBehaviour
{
    public int health;
    public int damage;
    public int range;

    void Start()
    {
        health = 6;
        damage = 1;
        range = 3;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        // Add additional logic like checking for death here
    }

    public void Attack(Archer target)
    {
        int damage = this.damage - target.defense;
        if (damage < 0) damage = 0;
        target.TakeDamage(damage);
    }
}
