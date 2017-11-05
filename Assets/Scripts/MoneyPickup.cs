using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPickup : MonoBehaviour
{
    public int MoneyValue = 10;
    private Text MoneyText;
    private AudioSource CoinSound;
    private SpriteRenderer Renderer;
    private Collider2D Collider;
    private static int TotalMoney;
    private static int LevelStartMoney;
    public GameObject Car;
    

    private void Start()
    {
        LevelStartMoney = PlayerValues.Player.money;
        MoneyText = GameObject.FindWithTag("Money").GetComponent<Text>();
        CoinSound = GetComponent<AudioSource>();
        Renderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
        TotalMoney = PlayerValues.Player.money;   
        MoneyText.text = "MONEY: " + TotalMoney;
    }

    private void AddMoney(int money)
    {
        TotalMoney += money;
    }

    public static int GetTotalMoney(){ return TotalMoney; }

    public static int GetEarnedLevelMoney(){ return TotalMoney - LevelStartMoney; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == Car.name)
        {
            CoinSound.Play();
            AddMoney(MoneyValue);
            MoneyText.text = "MONEY: " + TotalMoney;
            Renderer.enabled = false;
            Collider.enabled = false;
            Destroy(transform.gameObject,1);
        }

    }

}
