using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickUpTpye 
{
    Exp, Blood
}
public class PickUp : MonoBehaviour
{
    public AudioClip a;
    public PickUpTpye pickUpTpye;
    public float value;
    public float potionHealing;

    public float pickUpDistance;
    public float moveSpeed;

    private float originDistance;
    private float originSpeed;
    public Transform player;
    private void Awake()
    {
        originDistance = pickUpDistance;
        originSpeed = moveSpeed;
    }
    private void OnEnable()
    {
        pickUpDistance = originDistance;
        moveSpeed = originSpeed;
        if (pickUpTpye == PickUpTpye.Exp) 
        {
            float scale = Random.Range(1, 2f);
            transform.localScale = new Vector3(scale,scale,scale);
        }
    }
    private void Start()
    {
        player = FindAnyObjectByType<Player>().transform;
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position,player.position) < pickUpDistance) 
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.Translate (dir * moveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            CollectPickUp(collision);
        }
    }
    private void CollectPickUp(Collider2D collision) 
    {
        switch (pickUpTpye)
        {
            case PickUpTpye.Exp:
                AudioController.instance.PlaySE(a);
                PlayerData.getInstance().Exp += (int)value;
                //Debug.Log("Exp: "+ PlayerData.getInstance().Exp);          
                break;
            case PickUpTpye.Blood:
                if (PlayerData.getInstance().CurrentHealth == PlayerData.getInstance().CurrentMaxHealth)
                    return;
                PlayerData.getInstance().CurrentHealth += potionHealing;
                break;


        }
        ObjPoolManager.instance.ReturnObj(gameObject);

    }
}
