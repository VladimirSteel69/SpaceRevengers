using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AI : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    [SerializeField] private float lifeTime = 100f;

    


    //Upgrade
    [SerializeField] public int toPaySpd = 10;

    private Rigidbody2D Bullet_rb;
    // Start is called before the first frame update
    void Start()
    {
        Bullet_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //the bullet flyes
        Bullet_rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyAI>(out EnemyAI enemy)){
            Destroy(gameObject);
            MoneyScript.Instance.currentMoney += MoneyScript.Instance.moneyIncome; //primim bani cand omoram
        }
    }


    //Upgrade bullet speed
    public void ButtonPressed(){
        if(MoneyScript.Instance.currentMoney >= toPaySpd)
        {
            speed += 0.05f;                                  //Luam Upgradeul
            MoneyScript.Instance.currentMoney -= toPaySpd;  //scadem bani platiti
            toPaySpd = toPaySpd + toPaySpd/10;              //Marim pretu de upgrade
        }
    }
}
