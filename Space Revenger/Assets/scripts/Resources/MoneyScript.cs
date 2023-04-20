using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    //lets easy interactions
    public static MoneyScript Instance { get; private set; }              
  
     void Awake()     {
         if (Instance == null) {Instance = this; } else if (Instance != this) {Destroy(this); }
         DontDestroyOnLoad(gameObject);
     }
    
    public Text MyMoney;
    [SerializeField] public int currentMoney = 100;
    [SerializeField] public int moneyIncome = 10;
    [SerializeField] public int toPayMony = 10;

    private void Start() 
    {
        MyMoney.text = "Money: " + currentMoney;
    }

    //Monney counter text
    public void UpdateMoney()
    {
        MyMoney.text = "Money: " + currentMoney;
    }
    private void Update() {
        UpdateMoney();
    }


    //Money Upgrade
    public void MoneyUpgrade()
    {
        if(currentMoney >= toPayMony)
        {
            moneyIncome += moneyIncome/10;
            currentMoney -= toPayMony;
            toPayMony += toPayMony/10;
        }
    }
}
