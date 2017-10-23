using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPickup : MonoBehaviour
{
    public int MoneyValue = 1;
    private Text MoneyText;
    private static int TotalMoney;
    public GameObject Car;

    private void Start()
    {
        MoneyText = GameObject.FindWithTag("Money").GetComponent<Text>();
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
            AddMoney(MoneyValue);
            MoneyText.text = "MONEY: " + TotalMoney;
            Destroy(transform.gameObject);
        }

    }

}
