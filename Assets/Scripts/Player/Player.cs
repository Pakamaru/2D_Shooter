using System;
using UnityEngine;
using System.Linq;
public class Player : CombatUnit
{
    public int Level { get; set; }
    public float CurXP { get; set; }
    public float MaxXP { get; set; }

    [SerializeField]
    private GameObject upgradeCanvas;
    private GameController gameController;
    private PlayerUI ui;

    new void Start()
    {
        base.Start();
        upgradeCanvas.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        ui = GetComponent<PlayerUI>();
        Weapon = GetComponentInChildren<Weapon>();
    }

    public void GameStarted()
    {
        ui.SetXp(CurXP, MaxXP);
        ui.SetDamage(CurDmg);
        ui.SetAttackSpeed(Weapon.AttackSpeed);
        ui.SetReloadSpeed(Weapon.ReloadSpeed);
        ui.SetAmmo(Weapon.curMagazine, Weapon.MaxMagazine);
        ui.SetHealth(CurHealth, MaxHealth);
    }

    public void InitPlayer(Player player, Weapon weapon)
    {
        this.CurDmg = player.CurDmg;
        this.CurHealth = player.CurHealth;
        this.CurSpeed = player.CurSpeed;
        this.CurXP = player.CurXP;
        this.MaxDmg = player.MaxDmg;
        this.MaxHealth = player.MaxHealth;
        this.MaxSpeed = player.MaxSpeed;
        this.MaxXP = player.MaxXP;
        this.Weapon.SetVars(weapon.MaxMagazine, weapon.GetAS(), weapon.GetRS());
        this.Weapon.curMagazine = weapon.curMagazine;
        GameStarted();
    }

    public void AddXP(float xp)
    {
        CurXP += xp;
        ui.SetXp(CurXP, MaxXP);
        float tempXP = CurXP - MaxXP;
        if (tempXP >= 0)
        {
            Level++;
            ui.SetLevel(Level);
            MaxXP *= 1.5f;
            CurXP = 0;
            upgradeCanvas.SetActive(true);
            gameController.StopGameAndInput(true);
            AddXP(tempXP);
        }
    }

    public void DieRoutine()
    {
        gameController.LoseGame();
    }

    public override void TakeDamage(CombatUnit shooter)
    {
        base.TakeDamage(shooter);
        ui.SetHealth(CurHealth, MaxHealth);
    }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        ui.SetHealth(CurHealth, MaxHealth);
    }

    public void DmgUpgade()
    {
        MaxDmg = Mathf.RoundToInt(MaxDmg * 1.5f);
        CurDmg = MaxDmg;
        ui.SetDamage(CurDmg);
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void AttackSpeedUpgade()
    {
        Weapon.AttackSpeed = Weapon.AttackSpeed * 0.75f;
        ui.SetAttackSpeed(Weapon.AttackSpeed);
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void ReloadSpeedUpgrade()
    {
        Weapon.ReloadSpeed = Weapon.ReloadSpeed * 0.75f;
        ui.SetReloadSpeed(Weapon.ReloadSpeed);
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void MagazineUpgrade()
    {
        Weapon.MaxMagazine *= 2;
        ui.SetAmmo(Weapon.curMagazine, Weapon.MaxMagazine);
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void HealthUpgade()
    {
        MaxHealth = Mathf.RoundToInt(MaxHealth * 1.25f);
        CurHealth = MaxHealth;
        ui.SetHealth(CurHealth, MaxHealth);
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
}
