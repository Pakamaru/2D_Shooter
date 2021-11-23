using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : IState
{
    Enemy enemy;
    GameObject body;

    float range = 10.0f;
    float roadPassed = 0;
    private int patrolRange;

    public Patrol(Enemy enemy, int patrolRange, GameObject body)
    {
        this.enemy = enemy;
        this.patrolRange = patrolRange;
        this.body = body;
    }

    public void Tick()
    {
        if (roadPassed < range * 100)
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0 * enemy.CurSpeed, 1 * enemy.CurSpeed);
            roadPassed += 1 * enemy.CurSpeed;
        }
        else
        {
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0 * enemy.CurSpeed, -1 * enemy.CurSpeed);
            roadPassed += 1 * enemy.CurSpeed;
            if (roadPassed > range * 100 * 2)
                roadPassed = 0;
        }
    }

    public void OnEnter()
    {
        Color color = new Color(0, 1, 0);
        body.GetComponent<SpriteRenderer>().color = color;
    }

    public void OnExit()
    {
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        roadPassed = 0;
    }
}
