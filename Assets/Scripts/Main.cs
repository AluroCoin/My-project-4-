using UnityEngine;
using TMPro;


public class Main : MonoBehaviour
{
    private int num, diamond, control, click, price, auto, price_auto;
    public TextMeshProUGUI score, diamond_text, diamond_text_shop, text_up, text_auto, level_auto, level_click, text_shop, text_kashel;
    public GameObject main, shop, friend, kashel;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        if(PlayerPrefs.HasKey("num"))
        {
            num = PlayerPrefs.GetInt("num");
            score.text = num.ToString();
            diamond = PlayerPrefs.GetInt("diamond");
            diamond_text.text = diamond.ToString();
            diamond_text_shop.text = diamond.ToString();
            click = PlayerPrefs.GetInt("click");
            level_click.text =  click.ToString(); 
            auto = PlayerPrefs.GetInt("auto");
            level_auto.text = auto.ToString();
            price = PlayerPrefs.GetInt("price");
            text_up.text = "" + price;
            price_auto = PlayerPrefs.GetInt("price_auto");
            text_auto.text = "Btc:" + price_auto;
        }
        else
        {
            click = 1;
            price = 50;
            price_auto = 50;
            PlayerPrefs.SetInt("click", click);
            PlayerPrefs.SetInt("price", price);
            PlayerPrefs.SetInt("price_auto", price_auto);
        }
    }

    private void FixedUpdate ()
    {
        num += auto;
        PlayerPrefs.SetInt("num", num);
        control += auto;
        if(control > 10)
        {
            diamond = diamond + control / 10;
            PlayerPrefs.SetInt("diamond", diamond);
            diamond_text.text = diamond.ToString();
            diamond_text_shop.text = diamond.ToString();
            control = 0;
        }
        score.text = num.ToString();

    } 

    public void ClickButton()
    {
        num += click;
        control += click;
        if(control > 9)
        {
            diamond = diamond + control / 10;
            diamond_text.text = diamond.ToString();
            control = 0;
        }
        score.text = num.ToString();
    }

    public void ToShop()
    {
        main.SetActive(false);
        shop.SetActive(true);
        friend.SetActive(false);
        kashel.SetActive(false);
        diamond_text_shop.text = diamond.ToString();
    }

    
    public void ToFriend()
    {
        main.SetActive(false);
        friend.SetActive(true);
        shop.SetActive(false);
        kashel.SetActive(false);
        text_shop.text = diamond.ToString();
    }

    public void ToKashel()
    {
        main.SetActive(false);
        friend.SetActive(false);
        shop.SetActive(false);
        kashel.SetActive(true);
        text_shop.text = diamond.ToString();
    }

    public void Exit()
    {
        main.SetActive(true);
        shop.SetActive(false);
        friend.SetActive(false);
        kashel.SetActive(false);
        diamond_text_shop.text = diamond.ToString();
    }


    public void UpButton()
    {
        if(diamond > price)
        {
            click += 1;
            PlayerPrefs.SetInt("click", click);
            diamond -= price;
            diamond_text_shop.text = diamond.ToString();
            price += 50;
            PlayerPrefs.SetInt("price", price);
            text_up.text = "" + price;
            level_click.text =  click.ToString(); 

        }
    }

    public void Auto ()
    {
        if(diamond > price)
        {
            auto++;
            PlayerPrefs.SetInt("auto", auto);
            diamond -= price_auto;
            diamond_text_shop.text = diamond.ToString();
            price_auto += 10;
            PlayerPrefs.SetInt("price_auto", price_auto);
            text_auto.text = "Btc:" + price_auto;
            level_auto.text = auto.ToString() + "Alc";

        }

    }
}