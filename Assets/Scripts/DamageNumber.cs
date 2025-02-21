using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText;
    public float lifeTime;
    private float lifeCounter;

    private void Start()
    {
        lifeCounter = lifeTime;
    }
    private void Update()
    {
        if (lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;
            if (lifeCounter <= 0) 
            {
                ObjPoolManager.instance.ReturnObj(gameObject);
            }
        }
    }
    public void Setup(int damageDisplay) 
    {
        lifeCounter = lifeTime;
        damageText.text = damageDisplay.ToString(); 
    }
}
