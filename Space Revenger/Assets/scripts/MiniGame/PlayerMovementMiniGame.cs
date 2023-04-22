using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMiniGame : MonoBehaviour
{

    //scene change
    public Animator transition;


    public Transform player;
    public float speed = 5f;
    private int lives = 3;

    private bool isTouched = false;

    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;



    // Update is called once per frame
    void Update()
    {
        //Movementul de joystick
        if(Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetMouseButton(0))
        {
            isTouched = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            isTouched = false;
        }
    }

    void FixedUpdate()
    {
        //se executa actiunile doar atunci cand ecranul este atins
        if (isTouched)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1f);
            MoveCharacter(direction);
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void MoveCharacter(Vector2 direction)
    {
        //miscarea de translatie
        player.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D()
    {
        lives--;
        if(lives == 0)
        {
            LoadMainGame();
            Destroy(this.gameObject);
        }
    }

    public void LoadMainGame(){

        //play animation
        transition.SetTrigger("Start");
        //wait
        new WaitForSeconds(1);
        //Load scene
        SceneManager.LoadScene("MainGame");
    }
}
