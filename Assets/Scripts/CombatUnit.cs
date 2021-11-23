using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatUnit : MonoBehaviour
{
    public CombatUnit(int hp, int dmg, float speed)
    {
        this.MaxHealth = hp;
        this.MaxDmg = dmg;
        this.MaxSpeed = speed;

        this.CurHealth = MaxHealth;
        this.CurDmg = MaxDmg;
        this.CurSpeed = MaxSpeed;
    }

    public void SetVars(int hp, int dmg, float speed)
    {
        this.MaxHealth = hp;
        this.MaxDmg = dmg;
        this.MaxSpeed = speed;

        this.CurHealth = MaxHealth;
        this.CurDmg = MaxDmg;
        this.CurSpeed = MaxSpeed;

    }

    public Weapon Weapon { get; set; }

    public int MaxHealth { get; set; }
    public int MaxDmg { get; set; }
    public float MaxSpeed { get; set; }


    public int CurHealth { get; set; }
    public int CurDmg { get; set; }
    public float CurSpeed { get; set; }

    protected void Die()
    {
        print("You die");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && collision.gameObject.GetComponent<Bullet>().Shooter.gameObject != gameObject)
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().Shooter);
        }
    }

    private void TakeDamage(CombatUnit shooter)
    {
        Die();
        CurHealth -= shooter.CurDmg;
        if (CurHealth <= 0)
        {
            Die();
        }
    }
}
