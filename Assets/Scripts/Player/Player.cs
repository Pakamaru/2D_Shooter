using System;
using UnityEngine;
public class Player : CombatUnit
{
    public int Level { get; set; }
    public float CurXP { get; set; }
    public float MaxXP { get; set; }

    private GameObject upgradeCanvas;
    private GameController gameController;

    void Start()
    {
        upgradeCanvas = GameObject.Find("LevelUpMenu");
        upgradeCanvas.SetActive(false);
        gameController = FindObjectOfType<GameController>();
    }

    public void AddXP(float xp)
    {
        CurXP += xp;
        float tempXP = CurXP - MaxXP;
        if (tempXP >= 0)
        {
            CurXP = tempXP;
            Level++;
            upgradeCanvas.SetActive(true);
            gameController.StopGameAndInput(true);
        }
    }

    public void DmgUpgade()
    {
        MaxDmg = Mathf.RoundToInt(MaxDmg * 1.5f);
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void AttackSpeedUpgade()
    {
        Weapon.AttackSpeed = Weapon.AttackSpeed * 0.75f;
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void ReloadSpeedUpgrade()
    {
        Weapon.ReloadSpeed = Weapon.ReloadSpeed * 0.75f;
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void MagazineUpgrade()
    {
        Weapon.MaxMagazine *= 2;
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
    public void HealthUpgade()
    {
        MaxHealth = Mathf.RoundToInt(MaxHealth * 1.25f);
        CurHealth = MaxHealth;
        upgradeCanvas.SetActive(false);
        gameController.StopGameAndInput(false);
    }
}
