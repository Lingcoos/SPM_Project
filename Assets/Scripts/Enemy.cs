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
    public float maxHealht;


    public AudioClip vfDie;
    public UnityEvent OnHurt;
    public UnityEvent OnDie;



    public bool isHurt;
    public bool isDie;
    [HideInInspector]public Animator ani;
    private PickUpGenerator pickUpGenerator;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private Transform target;
    private Color originColor;
    private IState currentState;
    private float originSpeed;
    public bool live;
    Dictionary<EnemyStateType,IState> states = new Dictionary<EnemyStateType,IState>();


    private void Awake()
    {
        if(FindAnyObjectByType<Player>()!=null)
            target = FindAnyObjectByType<Player>().transform;
        else
            target = FindAnyObjectByType<PlayerNetWrok>().transform;
        maxHealht = Health;
        
        ani = GetComponent<Animator>(); 
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pickUpGenerator = GetComponent<PickUpGenerator>();
        originColor = sr.color;
        originSpeed = enemySpeed;
        states.Add(EnemyStateType.Idle, new EnemyIdleState(this));
        states.Add(EnemyStateType.Move, new EnemyMoveState(this));
        states.Add(EnemyStateType.Attack, new EnemyAttackState(this));
        states.Add(EnemyStateType.Hurt, new EnemyHurtState(this));
        states.Add(EnemyStateType.Die, new EnemyDieState(this));
        TransitionState(EnemyStateType.Move);
    }
    private void OnEnable()
    {
        live = true;
        enemySpeed = originSpeed;
        Health = maxHealht;
        isDie = false;
        isHurt = false;
        sr.color = originColor;
        TransitionState(EnemyStateType.Move);
        //Debug.Log("生命" + Health + "是否死亡"+isDie+"是否受伤" +isHurt);

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
        OnHurt?.Invoke();
        if (Health <= 0)
        { 
            OnDie.Invoke();
        }

    }
    public void FlashColor(float time)
    {
        sr.material.color = Color.red;
        Invoke("ResetColor", time);
    }
    private void ResetColor()
    {
        
        sr.material.color = originColor;
        isHurt = false;

    }

    public void EnemeyHurt() 
    {
        isHurt = true;
        AudioController.instance.PlaySE(vfDie);
    }
    public void EnemyDie() 
    {
        isDie = true;
        live = false;
    }
    public void EnemyDestroy() 
    {
        int kill = PlayerPrefs.GetInt("KillNum");
        kill++;
        PlayerPrefs.SetInt("KillNum", kill);
        pickUpGenerator.DropItems();
        isDie = false;
        ObjPoolManager.instance.ReturnObj(gameObject);
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
