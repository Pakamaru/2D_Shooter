using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : CombatUnit
{
    private GameObject player;
    private GameObject body;
    private RoomLayout roomLayout;
    private FieldOfView fieldOfView;

    private Vector3 startPos;
    private int watchRange;
    private int attackRange;

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
        fieldOfView = transform.GetComponent<FieldOfView>();

        stateMachine = new StateMachine();

        var attack = new Attack(this, Weapon, player, body);
        var patrol = new Patrol(this, body, player, roomLayout);
        var watch = new Watch(this, player, body);
        var reset = new Reset(this, startPos, body);

        At(patrol, watch, () => IsInWatchRange().Invoke() && IsPlayerInView().Invoke());
        //At(watch, reset, () => !IsInWatchRange().Invoke());
        At(watch, patrol, () => !IsInWatchRange().Invoke() || !IsPlayerInView().Invoke());
        At(watch, attack, IsInAttackRange());
        At(attack, watch, IsNotInAttackRangeAndInWatchRange());
        At(attack, patrol, () => !IsPlayerInView().Invoke());
        //At(reset, patrol, () =>  IsAtStartingPos().Invoke() && IsSceneLoaded().Invoke());
        At(reset, patrol, IsSceneLoaded());
        //At(reset, watch, IsInWatchRange());

        stateMachine.SetState(reset);

        void At(IState from, IState to, Func<bool> check) => stateMachine.AddTransition(from, to, check);
        Func<bool> IsInWatchRange() => () => Vector2.Distance(transform.position, player.transform.position) <= watchRange;
        Func<bool> IsInAttackRange() => () => Vector2.Distance(transform.position, player.transform.position) <= attackRange;
        Func<bool> IsNotInAttackRangeAndInWatchRange() => () => Vector2.Distance(transform.position, player.transform.position) > attackRange && Vector2.Distance(transform.position, player.transform.position) <= watchRange;
        //Func<bool> IsAtStartingPos() => () => transform.position == startPos;
        Func<bool> IsSceneLoaded() => () => SceneManager.GetActiveScene().isLoaded;
        Func<bool> IsPlayerInView() => () => fieldOfView.InView();

        watchRange = 5;
        attackRange = 3;
        //patrolRange = 1000;
    }

    // Start is called before the first frame update
    void Start()
    {
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
