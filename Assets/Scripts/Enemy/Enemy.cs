using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : CombatUnit
{
    private GameObject player;
    private GameObject body;
    private RoomLayout roomLayout;
    private FieldOfView fieldOfView;

    [SerializeField]
    private int attackRange;
    private Vector3 startPos;

    public float XPYield { get; set; }

    private StateMachine stateMachine;

    public void SetVars(int hp, int dmg, float speed, float xpYield)
    {
        base.SetVars(hp, dmg, speed);
        this.XPYield = xpYield;
    }

    private void Awake()
    {
        startPos = transform.position;
        body = transform.Find("Body").gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        roomLayout = GameObject.Find("Grid").GetComponent<RoomLayout>();
        fieldOfView = transform.GetComponent<FieldOfView>();
        Weapon = transform.Find("Gun").gameObject.GetComponent<Weapon>();
        Weapon.SetVars(this.gameObject, 10, 2, 5);

        stateMachine = new StateMachine();

        var attack = new Attack(this, Weapon, player, body);
        var patrol = new Patrol(this, body, player, roomLayout);
        var reset = new Reset(this, startPos, body);


        At(patrol, attack, () => IsInAttackRange().Invoke() && IsPlayerInView().Invoke());
        At(attack, patrol, () => !IsInAttackRange().Invoke() || !IsPlayerInView().Invoke());
        At(reset, patrol, IsSceneLoaded());

        stateMachine.SetState(reset);

        void At(IState from, IState to, Func<bool> check) => stateMachine.AddTransition(from, to, check);
        Func<bool> IsInAttackRange() => () => Vector2.Distance(transform.position, player.transform.position) <= attackRange;
        Func<bool> IsSceneLoaded() => () => SceneManager.GetActiveScene().isLoaded;
        Func<bool> IsPlayerInView() => () => fieldOfView.InView();
    }

    void Update()
    {
        stateMachine.Tick();
    }

    public void StartChildCoroutine(IEnumerator coroutineMethod)
    {
        StartCoroutine(coroutineMethod);
    }

    public void EndChildCoroutine(IEnumerator coroutineMethod)
    {
        StopCoroutine(coroutineMethod);
    }

    public Vector2 GetPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
