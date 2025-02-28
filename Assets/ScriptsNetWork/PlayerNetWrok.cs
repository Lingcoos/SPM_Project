using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Mirror;

/// <summary>
/// This class is responsible for the player's movement, health, and state transitions online.
/// </summary>
public class PlayerNetWrok : NetworkBehaviour
{
    [Header("Player")]
    public float curMaxHealth;
    public float curHealth;
    public float curSpeed;

    public UnityEvent onHurt;
    public UnityEvent onDie;


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
        


    }
    public override void OnStartLocalPlayer()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        PlayerData.getInstance().CurrentMaxHealth = curMaxHealth;
        PlayerData.getInstance().CurrentHealth = curHealth;
        PlayerData.getInstance().CurrentSpeed = curSpeed;

        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 0, Camera.main.transform.position.z);
        originColor = sr.color;
        states.Add(PlayerStateType.Idle, new PlayerIdleStateOnline(this));
        states.Add(PlayerStateType.Move, new PlayerMoveStateOnline(this));
        states.Add(PlayerStateType.Hurt, new PlayerHurtStateOnline(this));
        states.Add(PlayerStateType.Die, new PlayerDieStateOnline(this));
        
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
        if (!isLocalPlayer) 
            return;
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
        //Debug.Log("�ƶ����ݣ�" + InputValue);
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
        //Debug.Log("�ٶ�" + rig.velocity);
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
