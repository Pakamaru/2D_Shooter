using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatUnit
{
    public Player(int hp, int dmg, float speed) : base(hp, dmg, speed)
    {
    }

    void Start()
    {
        Weapon = transform.Find("Body").Find("Gun").gameObject.GetComponent<Weapon>();
        //print(Weapon);
        Weapon.SetVars(this.gameObject, 10, 2, 5);
    }
}
