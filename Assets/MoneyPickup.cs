using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPickup : MonoBehaviour
{
    public int MoneyValue = 1;
    private Text MoneyText;
    private AudioSource CoinSound;
    private SpriteRenderer Renderer;
    private static int TotalMoney;
    public GameObject Car;
    

    private void Start()
    {
        MoneyText = GameObject.FindWithTag("Money").GetComponent<Text>();
        CoinSound = GetComponent<AudioSource>();
        Renderer = GetComponent<SpriteRenderer>();
        TotalMoney = PlayerValues.Player.money;
        MoneyText.text = "MONEY: " + TotalMoney;
    }

    private void AddMoney(int money)
    {
        TotalMoney += money;
    }

    public static int GetTotalMoney(){ return TotalMoney; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == Car.name)
        {
            CoinSound.Play();
            AddMoney(MoneyValue);
            MoneyText.text = "MONEY: " + TotalMoney;
            Renderer.enabled = false;
            Destroy(transform.gameObject,1);
        }

    }

}
