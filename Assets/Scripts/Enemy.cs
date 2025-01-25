using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStateType 
{
    Idle,Move,Attack,Hurt,Die
}
public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float Health = 10000;

    public GameObject exp;


    private Rigidbody2D rig;
    private SpriteRenderer spr;
    private Transform target;
    private IState currentState;
    Dictionary<EnemyStateType,IState> states = new Dictionary<EnemyStateType,IState>();

    private void Awake()
    {
        target = FindAnyObjectByType<Player>().transform;
        rig = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
        states.Add(EnemyStateType.Move, new EnemyMoveState(this));
        states.Add(EnemyStateType.Attack, new EnemyAttackState(this));
        states.Add(EnemyStateType.Hurt, new EnemyHurtState(this));
        states.Add(EnemyStateType.Die, new EnemyDieState(this));
        TransitionState(EnemyStateType.Idle);
    }
    public void TransitionState(EnemyStateType type) 
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
    private void Update()
    {
        ChasePlayer();
        if (Health <= 0) 
        {
            Instantiate(exp, transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void ChasePlayer() 
    {
        Vector2 dir = (target.position - transform.position).normalized;
        //Debug.Log("方向"+ dir);
        if (dir.x > 0)
            spr.flipX = true;
        else
            spr.flipX = false;
        rig.velocity = dir * enemySpeed ;
        //Debug.Log("敌人速度" + rig.velocity);
    }
}
