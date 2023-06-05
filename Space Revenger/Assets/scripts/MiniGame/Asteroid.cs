using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rb;
    private Vector2 screenBounds;
    private float rotationSpeed;


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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<PlayerMovementMiniGame>(out PlayerMovementMiniGame player))
        {
            Destroy(this.gameObject);
        }
    }

    void RotateLeft () 
    {
        transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
