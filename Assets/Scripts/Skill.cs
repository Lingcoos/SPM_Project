using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int ID;
    public string nameSkill;
    public int price;
    public bool isAlreadyBuy;
    public Sprite normImage;
    public Sprite lockImage;
    public Text priceText;
    public Text nameText;
    public Text descibleText;
    public LocalizedString priceString;
    public LocalizedString nameSkillString;
    public LocalizedString describleString;
    private Sprite originImage;
    private Image image;
    

    private void Awake()
    {
        image = GetComponent<Image>();
        //PlayerPrefs.SetInt("Skill1", 0);
        //PlayerPrefs.SetInt("Skill2", 0);
        //PlayerPrefs.SetInt("Skill3", 0);
        //PlayerPrefs.SetInt("Score", 100);
        priceString.TableEntryReference = "Price";
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
    
    private void Update()
    {
        priceText.text = priceString.GetLocalizedString() + price.ToString();
        nameText.text = nameSkillString.GetLocalizedString();
        descibleText.text = describleString.GetLocalizedString();
        //Debug.Log("1: " + PlayerPrefs.GetInt("Skill1") + " 2: " + PlayerPrefs.GetInt("Skill2") + " 3: " + PlayerPrefs.GetInt("Skill3"));
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
                PlayerData.getInstance().ChangeSkill(ID);
            }   
        }
    }

    

}
