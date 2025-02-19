using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
public enum EnemyStateType 
{
    Idle,Move,Attack,Hurt,Die
}
public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float colliderDamage;
    public float colliderDisntance;
    public LayerMask playerMask;
    public float Health;

    public UnityEvent OnHurt;
    public UnityEvent OnDie;


    
    //private bool isHurt;
    //private bool isDie;
    [HideInInspector]public Animator ani;
    private PickUpGenerator pickUpGenerator;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private Transform target;
    private Color originColor;
    private IState currentState;
    Dictionary<EnemyStateType,IState> states = new Dictionary<EnemyStateType,IState>();

    private void Awake()
    {
        target = FindAnyObjectByType<Player>().transform;
        ani = GetComponent<Animator>(); 
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pickUpGenerator = GetComponent<PickUpGenerator>();
        originColor = sr.color;
        states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
        states.Add(EnemyStateType.Move, new EnemyMoveState(this));
        states.Add(EnemyStateType.Attack, new EnemyAttackState(this));
        states.Add(EnemyStateType.Hurt, new EnemyHurtState(this));
        states.Add(EnemyStateType.Die, new EnemyDieState(this));
        TransitionState(EnemyStateType.Move);
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
    }
    private void FixedUpdate()
    {
        //ColliderAttack();
        currentState.OnFixUpData();
    }
    public void ChasePlayer()
    {
        Vector2 dir = (target.position - transform.position).normalized;
        //Debug.Log("方向"+ dir);
        if (dir.x > 0)
            sr.flipX = true;
        else
            sr.flipX = false;
        rig.velocity = dir * enemySpeed;
        //Debug.Log("敌人速度" + rig.velocity);
    }

    public void GetDamage(float damage) 
    {
        Health -= damage;
        FlashColor(0.5f);
        OnHurt?.Invoke();
        if (Health <= 0)
        {
            OnDie?.Invoke();
        }

    }
    private void FlashColor(float time)
    {
        sr.material.color = Color.red;
        Invoke("ResetColor", time);
    }
    private void ResetColor()
    {
        
        sr.material.color = originColor;
    }

    public void EnemyHurt() 
    {
        //isHurt = true;  
    }
    public void EnemyDestory() 
    {
        //isDie = true;
        pickUpGenerator.DropItems();
        Destroy(gameObject);
    }
    public void ColliderAttack() 
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, colliderDisntance, playerMask);
        foreach (Collider2D hitCollider in hitColliders) 
        {
            if (hitCollider.CompareTag("Player")) 
            {
                hitCollider.GetComponent<Player>().GetDamage(colliderDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<Player>().GetDamage(colliderDamage);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(transform.position, colliderDisntance);
    //}
}
