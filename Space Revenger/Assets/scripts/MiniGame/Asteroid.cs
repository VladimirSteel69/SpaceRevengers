using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rb;
    private Vector2 screenBounds;
    private float rotationSpeed;
    public Transform asteroid;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = Random.Range(-30f, 30f);
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
        RotateLeft();
        if (transform.position.y < screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(explosion, new Vector2(asteroid.position.x, asteroid.position.y), Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, new Vector2(asteroid.position.x, asteroid.position.y), Quaternion.identity);
        Destroy(gameObject);
    }

    void RotateLeft () 
    {
        transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
