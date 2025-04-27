using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    public GameObject dirPoint;
    bool finishTimer;
    ScytheController weapon;
    void Start()
    {
        weapon = dirPoint.transform.parent.parent.GetComponent<ScytheController>();
        StartCoroutine(Timer(weapon.returnTimer()));
        //Debug.Log("Éú³ÉÎäÆ÷");
    }
    private void Update()
    {
        
        dirPoint.transform.Translate(weapon.speed * Vector3.right * Time.deltaTime);
        transform.Rotate(-Vector3.forward * weapon.turnSpeed * Time.deltaTime, Space.Self);
        if (finishTimer) 
        {
            //Debug.Log("yes");
            Destroy(dirPoint);
        }

        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            collision.GetComponent<Enemy>().GetDamage(weapon.damage + PlayerData.getInstance().ExtraDamge);
            DamageNumberController.instance.SpawnDamage(weapon.damage + PlayerData.getInstance().ExtraDamge, collision.transform.position);
        }
    }
    IEnumerator Timer(float timer) 
    {
        for (int i = 0; i < timer; i++) 
        {
            yield return new WaitForSeconds(1);
            //Debug.Log(i);
        }
        float remainTime = timer - (int)timer;
        if (remainTime != 0) 
        {
            
            yield return new WaitForSeconds(remainTime);
            //Debug.Log(timer);
            
        }
        finishTimer = true;
    }



}
