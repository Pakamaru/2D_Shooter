using UnityEngine;

public abstract class CombatUnit : MonoBehaviour
{
    private HealthBar healthBar;

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

    private void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        print(healthBar);
        healthBar.SetHealth(1, 1);
    }

    protected void Die(CombatUnit shooter)
    {
        if (shooter.GetType().Name == "Player")
        {
            FindObjectOfType<GameController>().currentRoom.KillOneEnemy();
            shooter.GetComponent<Player>().AddXP(transform.GetComponent<Enemy>().XPYield);
        }
        else if (shooter.GetType().Name == "Enemy")
        {
            print("You die");
        }
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!collision.gameObject.GetComponent<Bullet>().Shooter.CompareTag(gameObject.tag))
            {
                TakeDamage(collision.gameObject.GetComponent<Bullet>().Shooter);
                Destroy(collision.gameObject);
            }
        }
    }

    private void TakeDamage(CombatUnit shooter)
    {
        CurHealth -= shooter.CurDmg;
        print(healthBar);
        //healthBar.SetHealth(CurHealth, MaxHealth);
        if (CurHealth <= 0)
        {
            Die(shooter);
        }
    }
}
