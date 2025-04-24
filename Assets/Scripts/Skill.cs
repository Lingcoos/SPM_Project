using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int ID;
    public string nameSkill;
    public int price;
    public bool isAlreadyBuy;
    public Sprite normImage;
    public Sprite lockImage;
    private Sprite originImage;
    private Image image;
    

    private void Awake()
    {
        image = GetComponent<Image>();
        //PlayerPrefs.SetInt("Skill1", 0);
        //PlayerPrefs.SetInt("Score", 100);
    }

    private void Start()
    {
        originImage = image.sprite;
        if (isAlreadyBuy || PlayerPrefs.GetInt($"Skill{ID}") == 1)
        {

        }
        else 
        {
            image.sprite = lockImage;
            PlayerPrefs.SetInt($"Skill{ID}", 0);
        }
    }

    public void HandleClickSkill()
    {
        if (isAlreadyBuy || PlayerPrefs.GetInt($"Skill{ID}") == 1)
        {
            Debug.Log("¼¤»îÌì¸³");
        }
        else 
        {
            if (PlayerPrefs.GetInt("Score") >= price) 
            {
                int money = PlayerPrefs.GetInt($"Score");
                money -= price;
                PlayerPrefs.SetInt("Score", money);
                image.sprite = originImage;
                isAlreadyBuy = true;
                PlayerData.getInstance().ChangeSkill(1);
            }   
        }
    }

    

}
