using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyNetWork : NetworkBehaviour
{
    public float enemySpeed;
    public float colliderDamage;
    public float colliderDisntance;
    public LayerMask playerMask;
    public float Health;
    public float maxHealht;

    public UnityEvent OnHurt;
    public UnityEvent OnDie;



    private bool isHurt;
    public bool isDie;
    [HideInInspector] public Animator ani;
    private PickUpGenerator pickUpGenerator;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private Transform target;
    private Color originColor;
    private IState currentState;
    Dictionary<EnemyStateType, IState> states = new Dictionary<EnemyStateType, IState>();


    private void Awake()
    {

            
        maxHealht = Health;

        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pickUpGenerator = GetComponent<PickUpGenerator>();
        originColor = sr.color;
        states.Add(EnemyStateType.Idle, new EnemyIdleStateOnline(this));
        states.Add(EnemyStateType.Move, new EnemyMoveStateOnline(this));
        states.Add(EnemyStateType.Attack, new EnemyAttackStateOnline(this));
        states.Add(EnemyStateType.Hurt, new EnemyHurtStateOnline(this));
        states.Add(EnemyStateType.Die, new EnemyDieStateOnline(this));
        TransitionState(EnemyStateType.Move);
    }
    private void OnEnable()
    {

        Health = maxHealht;
        isDie = false;
        sr.color = originColor;

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
        if (FindAnyObjectByType<PlayerNetWrok>()!=null)
            target = FindAnyObjectByType<PlayerNetWrok>().transform;
        currentState.OnUpData();
    }
    private void FixedUpdate()
    {
        //ColliderAttack();
        currentState.OnFixUpData();
    }
    [Server]
    public void ChasePlayer()
    {
        if(target == null)
            return;
        Vector2 dir = (target.position - transform.position).normalized;
        //Debug.Log("方向"+ dir);
        if (dir.x > 0)
            sr.flipX = true;
        else
            sr.flipX = false;
        rig.velocity = dir * enemySpeed;
        //Debug.Log("敌人速度" + rig.velocity);
    }
    [Server]
    public void GetDamage(float damage)
    {
        Health -= damage;
        FlashColor(0.1f);
        OnHurt?.Invoke();
        if (Health <= 0)
        {
            isDie = true;
            OnDie.Invoke();
        }

    }
    [Server]
    private void FlashColor(float time)
    {
        sr.material.color = Color.red;
        Invoke("ResetColor", time);
    }
    [Server]
    private void ResetColor()
    {

        sr.material.color = originColor;

    }

    public void EnemyHurt()
    {
        //isHurt = true;  
    }
    [Server]
    public void EnemyDestory()
    {

        //pickUpGenerator.DropItems();
        Destroy(gameObject);
        //ObjPoolManager.instance.ReturnObj(gameObject);
    }

    [Server]
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerNetWrok>().GetDamage(colliderDamage);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, colliderDisntance);
    //}
}
