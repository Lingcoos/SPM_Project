using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStateType 
{
    Idle,Move,Hurt,Die
}
public class Enemy : MonoBehaviour
{
    public float enemySpeed;

    [HideInInspector]public Animator ani;
    private Rigidbody2D rig;
    private SpriteRenderer spr;
    private Transform target;
    private IState currentState;
    private Dictionary<EnemyStateType,IState> states = new Dictionary<EnemyStateType,IState>();
    private void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();  
        spr = GetComponent<SpriteRenderer>();
        target = FindObjectOfType<Player>().transform;
        states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
        states.Add(EnemyStateType.Move, new EnemyMoveState(this));
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
        currentState.OnUpData();
        ChasePlayer();
    }

    private void FixedUpdate()
    {
        currentState.OnFixUpData();
    }

    public void ChasePlayer()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        if (dir.x > 0) 
            spr.flipX = true;
        else
            spr.flipX = false;
        rig.velocity = dir * enemySpeed * Time.deltaTime*10;
        Debug.Log("µ–»ÀÀŸ∂»" + rig.velocity);
    }
}
