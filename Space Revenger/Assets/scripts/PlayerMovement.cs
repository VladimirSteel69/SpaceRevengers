using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 200f; //variabila de viteza

    // Gun things
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform FiringPoint;
    [SerializeField] private float fireRate = 0.5f;
    private float fireTimer = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(fireTimer <= 0f){
        Shoot();
        fireTimer = fireRate;
        }
    }

    private void Shoot(){
        Instantiate(Bullet, FiringPoint.position, FiringPoint.rotation);
    }

    


    void Update()
    {
            fireTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0) //monitorizare atingerilor(in cazul in care sunt mai multe)
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

        // Gun things (if same angle shoot)
        /*if(enemy)
            if(Vector3.Angle(enemy.transform.forward, transform.position - enemy.transform.position) < angle && fireTimer <= 0f){
                Shoot();
                fireTimer = fireRate;
        }else fireTimer -= Time.deltaTime;*/
    }

}
