using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.InputSystem;
public enum PlayerStateType
{
    Idle, Move, Hurt, Die
}
public class Player : MonoBehaviour
{
    [Header("Player")]
    public float playerSpeed;





    [HideInInspector] public bool isRuning;
    private Vector2 InputValue;
    [HideInInspector]public Animator ani;
    private Rigidbody2D rig;
    private IState currentState;
    private Dictionary<PlayerStateType,IState> states = new Dictionary<PlayerStateType,IState>();
    private void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
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
        
    }
    private void FixedUpdate()
    {
        
        currentState.OnFixUpData();
    }
    public void OnMove(InputValue value)
    {
        InputValue = value.Get<Vector2>();
        //Debug.Log("移动数据：" + InputValue);
    }
    public void Move()
    {
        if (InputValue.magnitude > 0.0001f) 
            isRuning = true;    
        else
            isRuning = false;
        ani.SetFloat("LookX",InputValue.x);
        ani.SetFloat("LookY",InputValue.y);
        rig.velocity =  InputValue *  playerSpeed;
        //Debug.Log("速度" + rig.velocity);
    }
}
