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
    }
    public void ChasePlayer() 
    {
        Vector2 dir = (target.position - transform.position).normalized;
        Debug.Log("����"+ dir);
        if (dir.x > 0)
            spr.flipX = true;
        else
            spr.flipX = false;
        rig.velocity = dir * enemySpeed ;
        Debug.Log("�����ٶ�" + rig.velocity);
    }
}
