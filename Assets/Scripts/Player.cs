using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Mirror;

/// <summary>
/// Enum for player state
/// </summary>
public enum PlayerStateType
{
    Idle, Move, Hurt, Die
}

/// <summary>
/// This class is responsible for the player's movement, health, and state transitions.
/// </summary>
public class Player : MonoBehaviour
{
    [Header("Player")]
    public float curMaxHealth;
    public float curHealth;
    public float curSpeed;
    public bool isSkill1;
    public UnityEvent onHurt;
    public UnityEvent onDie;

    public GameObject pickUpSet;
    [HideInInspector] public bool isRuning;
    [HideInInspector] public bool isHurt;

    private Color originColor;
    private Vector2 InputValue;
    [HideInInspector]public Animator ani;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private IState currentState;
    private Dictionary<PlayerStateType,IState> states = new Dictionary<PlayerStateType,IState>();



    /// <summary>
    /// When the player is created, the player's state is set to idle.
    /// </summary>
    private void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        PlayerData.getInstance().CurrentMaxHealth = curMaxHealth;
        PlayerData.getInstance().CurrentHealth = curHealth;
        PlayerData.getInstance().CurrentSpeed = curSpeed;
        
        originColor = sr.color;
        states.Add(PlayerStateType.Idle, new PlayerIdleState(this));
        states.Add(PlayerStateType.Move, new PlayerMoveState(this));
        states.Add(PlayerStateType.Hurt, new PlayerHurtState(this));
        states.Add(PlayerStateType.Die, new PlayerDieState(this));
        TransitionState(PlayerStateType.Idle);
    }

    
    public void TransitionState(PlayerStateType type) 
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
        Move();
        currentState.OnUpData();
        curMaxHealth = PlayerData.getInstance().CurrentMaxHealth;
        curHealth = PlayerData.getInstance().CurrentHealth;
        curSpeed = PlayerData.getInstance().CurrentSpeed;

    }
    private void FixedUpdate()
    {
        currentState.OnFixUpData();
    }
    #region Input
    public void OnMove(InputAction.CallbackContext ctx)
    {
        InputValue = ctx.ReadValue<Vector2>();
        
    }
    public void OnSkill1() 
    {
        if (isSkill1 && PlayerPrefs.GetInt("Skill1") == 1) 
        {
            PickUpAllItem();
            Debug.Log("发动技能");
        }       
    }

    #endregion

    public void Move()
    {
        if (InputValue.magnitude > 0.0001f) 
            isRuning = true;    
        else
            isRuning = false;
        ani.SetFloat("LookX",InputValue.x);
        ani.SetFloat("LookY",InputValue.y);
        rig.velocity = InputValue * PlayerData.getInstance().CurrentSpeed;
        
    }
    public void PickUpAllItem() 
    {
        for (int i = 0; i < pickUpSet.transform.childCount; i++) 
        {
            if (pickUpSet.transform.GetChild(i).gameObject.activeSelf)
            {
                pickUpSet.transform.GetChild(i).GetComponent<PickUp>().pickUpDistance = 1000000;
                pickUpSet.transform.GetChild(i).GetComponent<PickUp>().moveSpeed *= 4;
            }
        }  
    }
    public void GetDamage(float damage) 
    {
        if (damage <= 0)
            return;
        PlayerData.getInstance().CurrentHealth -= damage;
        onHurt?.Invoke();
        if (PlayerData.getInstance().CurrentHealth <= 0) 
        {
            onDie?.Invoke();
        }  
    }
    public void PlayerHurt() 
    {
        isHurt = true;
        Controller.instance.StartVibration(1f, 1f, 0.5f);
        FlashColor(0.5f);
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
}
