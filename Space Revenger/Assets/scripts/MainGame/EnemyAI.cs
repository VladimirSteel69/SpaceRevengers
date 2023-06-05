using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public bool PlayGame = false;

    public float speed = 5f;
    public float rotateSpeed = 2000f;

    private Rigidbody2D rb;

    public GameObject explosion;
    public Transform enemy;


    public void startgame(){
        PlayGame = true;
        
    }
    public void stopgame(){
        PlayGame = false;
    }
        
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed;
    }

    private void Update() {
        if(PlayGame == false)
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Bullet_AI>(out Bullet_AI Bullet)){
            Instantiate(explosion, new Vector2(enemy.position.x, enemy.position.y), Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Instantiate(explosion, new Vector2(enemy.position.x, enemy.position.y), Quaternion.identity);
        Destroy(gameObject);
    }
}
