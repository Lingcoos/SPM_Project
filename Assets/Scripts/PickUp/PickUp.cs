using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PickUpTpye 
{
    Exp, Coin, Blood
}
public class PickUp : MonoBehaviour
{
    public PickUpTpye pickUpTpye;
    public float value;
    public float potionHealing;

    public float pickUpDistance;
    public float moveSpeed;
    public Transform player;

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
                PlayerData.getInstance().Exp += (int)value;
                Debug.Log("Exp: "+ PlayerData.getInstance().Exp);
                Destroy(gameObject);
                break;
            case PickUpTpye.Coin:
                break;
            case PickUpTpye.Blood:
                break;
        }
           
    }
}
