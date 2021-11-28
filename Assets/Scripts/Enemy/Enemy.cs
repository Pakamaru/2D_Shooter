using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : CombatUnit
{
    private GameObject player;
    private GameObject body;
    private RoomLayout roomLayout;

    private Vector3 startPos;
    private int watchRange;
    private int attackRange;
    private int patrolRange;
    //private List<Vector3> patrolPositions;

    private StateMachine stateMachine;

    public Enemy(int hp, int dmg, float speed) : base(hp, dmg, speed)
    {
    }

    private void Awake()
    {
        startPos = transform.position;
        body = transform.Find("Body").gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        roomLayout = GameObject.Find("Grid").GetComponent<RoomLayout>();

        stateMachine = new StateMachine();

        var attack = new Attack(this, Weapon, player, body);
        var patrol = new Patrol(this, patrolRange, body, player, roomLayout);
        var watch = new Watch(this, player, body);
        var reset = new Reset(this, startPos, body);

        At(patrol, watch, IsInWatchRange());
        At(watch, reset, () => !IsInWatchRange().Invoke());
        At(watch, attack, IsInAttackRange());
        At(attack, watch, IsNotInAttackRangeAndInWatchRange());
        At(reset, patrol, () =>  IsAtStartingPos().Invoke() && IsSceneLoaded().Invoke());
        At(reset, watch, IsInWatchRange());

        stateMachine.SetState(reset);

        void At(IState from, IState to, Func<bool> check) => stateMachine.AddTransition(from, to, check);
        Func<bool> IsInWatchRange() => () => Vector2.Distance(transform.position, player.transform.position) <= watchRange;
        Func<bool> IsInAttackRange() => () => Vector2.Distance(transform.position, player.transform.position) <= attackRange;
        Func<bool> IsNotInAttackRangeAndInWatchRange() => () => Vector2.Distance(transform.position, player.transform.position) > attackRange && Vector2.Distance(transform.position, player.transform.position) <= watchRange;
        Func<bool> IsAtStartingPos() => () => transform.position == startPos;
        Func<bool> IsSceneLoaded() => () => SceneManager.GetActiveScene().isLoaded;

        watchRange = 20;
        attackRange = 15;
        patrolRange = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        //patrolPositions = new List<Vector3>();
        //patrolPositions.Add(new Vector3())

        Weapon = transform.Find("Gun").gameObject.GetComponent<Weapon>();
        Weapon.SetVars(this.gameObject, 10, 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Tick();
    }

    public Vector2 GetPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
