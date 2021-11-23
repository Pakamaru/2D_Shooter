using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : IState
{
    private Enemy enemy;
    private Vector3 startPos;
    private GameObject body;

    public Reset(Enemy enemy, Vector3 startPos, GameObject body)
    {
        this.enemy = enemy;
        this.startPos = startPos;
        this.body = body;
    }

    public void Tick()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, startPos, enemy.CurSpeed * Time.deltaTime);
    }

    public void OnEnter()
    {
        Color color = new Color(0, 1, 0 , 0.5f);
        body.GetComponent<SpriteRenderer>().color = color;
    }

    public void OnExit()
    {
        Color color = new Color(0, 1, 0);
        body.GetComponent<SpriteRenderer>().color = color;
    }
}
