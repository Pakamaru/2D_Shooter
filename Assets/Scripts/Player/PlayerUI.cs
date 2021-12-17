using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private TextMeshProUGUI ammo;
    private TextMeshProUGUI level;
    private TextMeshProUGUI xp;
    private TextMeshProUGUI health;
    private TextMeshProUGUI damage;
    private TextMeshProUGUI attackSpeed;
    private TextMeshProUGUI reloadSpeed;

    void Start()
    {
        ammo = GameObject.Find("Ammo").GetComponent<TextMeshProUGUI>();
        level = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        xp = GameObject.Find("ExperienceCount").GetComponent<TextMeshProUGUI>();
        health = GameObject.Find("HealthCount").GetComponent<TextMeshProUGUI>();
        damage = GameObject.Find("Damage").GetComponent<TextMeshProUGUI>();
        attackSpeed = GameObject.Find("AttackSpeed").GetComponent<TextMeshProUGUI>();
        reloadSpeed = GameObject.Find("ReloadSpeed").GetComponent<TextMeshProUGUI>();
    }

    public void SetAmmo(int cur, int max)
    {
        ammo.text = "Bullets " + cur + "/" + max;
    }
    public void SetLevel(int txt)
    {
        level.text = "Level " + txt;
    }
    public void SetXp(float cur, float max)
    {
        print("xp float: " + cur + ", " + max + " xp int: " + (int)cur + ", " + (int)max);
        xp.text =  (int)cur + "/" + (int)max;
    }
    public void SetHealth(int cur, int max)
    {
        health.text = cur + "/" + max;
    }
    public void SetDamage(int txt)
    {
        damage.text = "Damage " + txt;
    }
    public void SetAttackSpeed(float txt)
    {
        attackSpeed.text = "Attack Speed " + txt;
    }
    public void SetReloadSpeed(float txt)
    {
        reloadSpeed.text = "Reload Speed " + txt;
    }
}
