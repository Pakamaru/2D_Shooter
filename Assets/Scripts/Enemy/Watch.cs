using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : IState
{
    GameObject player;
    Enemy enemy;
    GameObject body;

    public Watch(Enemy enemy, GameObject player, GameObject body)
    {
        this.enemy = enemy;
        this.player = player;
        this.body = body;
    }

    public void Tick()
    {
        Vector3 dir = player.transform.position - enemy.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    public void OnEnter()
    {
        Color color = new Color(1, 0.5f, 0);
        body.GetComponent<SpriteRenderer>().color = color;
    }

    public void OnExit()
    {
        Color color = new Color(0, 1, 0);
        body.GetComponent<SpriteRenderer>().color = color;
    }
}
