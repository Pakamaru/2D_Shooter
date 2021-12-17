using System;
using UnityEngine;
public class Player : CombatUnit
{
    public int Level { get; set; }
    public float CurXP { get; set; }
    public float MaxXP { get; set; }

    private GameObject upgradeCanvas;
    private GameController gameController;
    private PlayerUI ui;

    new void Start()
    {
        base.Start();
        upgradeCanvas = GameObject.Find("LevelUpMenu");
        upgradeCanvas.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        ui = GetComponent<PlayerUI>();
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

    public void AddXP(float xp)
    {
        CurXP += xp;
        ui.SetXp(CurXP, MaxXP);
        float tempXP = CurXP - MaxXP;
        if (tempXP >= 0)
        {
            Level++;
            print(Level);
            ui.SetLevel(Level);
            MaxXP *= 1.5f;
            upgradeCanvas.SetActive(true);
            gameController.StopGameAndInput(true);
            AddXP(tempXP);
        }
    }

    public void DieRoutine()
    {

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
