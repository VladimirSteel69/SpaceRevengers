using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AI : MonoBehaviour
{

    [SerializeField] private float speed = 1f;

    [SerializeField] private float lifeTime = 100f;

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
        }
    }


    //Upgrade
    public void ButtonPressed(){
        speed += 0.05f;
    }
}
