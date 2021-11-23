using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : IState
{
    private Enemy enemy;
    private Weapon weapon;
    private GameObject player;
    private GameObject body;

    public Attack(Enemy enemy, Weapon weapon, GameObject player, GameObject body)
    {
        this.enemy = enemy;
        this.weapon = weapon;
        this.player = player;
        this.body = body;
    }

    public void Tick()
    {
        Vector3 dir = player.transform.position - enemy.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        if (Vector2.Distance(enemy.transform.position, player.transform.position) > 5)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, enemy.CurSpeed * Time.deltaTime);
        }
        weapon.Shoot();
    }

    public void OnEnter()
    {
        Color color = new Color(1, 0, 0);
        body.GetComponent<SpriteRenderer>().color = color;
    }

    public void OnExit()
    {
        Color color = new Color(0, 1, 0);
        body.GetComponent<SpriteRenderer>().color = color;
    }
}
