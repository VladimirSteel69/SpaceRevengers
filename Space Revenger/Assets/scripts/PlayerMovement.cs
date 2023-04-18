using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 200f; //variabila de viteza
    [SerializeField] public bool movement = false;

    // Gun things
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform FiringPoint;
    [SerializeField] public float fireRate = 0.2f;
    [SerializeField] private float fireTimer;
    [SerializeField] public float NextToFire;


    
    //Upgrade Things
    [SerializeField] public int toPayAtk = 10;
    [SerializeField] public int toPayMove = 10;


    //AttackSpeed Upgrade
    public void ButtonPressedAtSpd(){
        if(fireRate > 0.1f && MoneyScript.Instance.currentMoney >= toPayAtk)
        {
            fireRate += 0.05f;                                  //Luam Upgradeul
            MoneyScript.Instance.currentMoney -= toPayAtk;      //Scadem cat costa din bani
            toPayAtk = toPayAtk + toPayAtk/10;                  //Marim Pretu de Upgrade
        }

    }

    //MovementSpeed Upgrade
    public void ButtonPressedMoveSpd(){
        if(MoneyScript.Instance.currentMoney >= toPayMove)
        {
            speed += 10f;
            MoneyScript.Instance.currentMoney -= toPayMove;
            toPayMove = toPayMove + toPayMove/10;
        }
    }


    //Shoot function
    private void OnTriggerStay2D(Collider2D collision) {
        if(fireTimer >= NextToFire){
             Shoot();
            fireTimer = 0;
     }
    }
    private void Shoot(){
        Instantiate(Bullet, FiringPoint.position, FiringPoint.rotation);
    }


    public void enableMovement(){
        movement = true;
    }

    public void disableMovement(){
        movement = false;
    }
    
    void Update()
    {
        //FireRate things
        fireTimer += Time.fixedDeltaTime;
        NextToFire = 1/ fireRate;
        
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0 && movement == true) //monitorizare atingerilor(in cazul in care sunt mai multe)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)    //se verifica daca ecranul este apsat
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.WorldToScreenPoint(transform.position).z)); //converteste coordonatele din lumea din unity in pixeli pe ecran
                if (touch.position.x < Screen.width/2.0f) //verifica daca atingerea este in partea stanga a ecranului
                {
                    transform.RotateAround(Vector3.zero, Vector3.forward, speed * Time.fixedDeltaTime); //rotirea spre stanga
                }
                else if (touch.position.x > Screen.width/2.0f) //verifica daca atingerea este in partea dreapta a ecranului
                {
                    transform.RotateAround(Vector3.zero, Vector3.forward, -speed * Time.fixedDeltaTime); //rotirea spre dreapta
                }
            }
        }
    }

}
