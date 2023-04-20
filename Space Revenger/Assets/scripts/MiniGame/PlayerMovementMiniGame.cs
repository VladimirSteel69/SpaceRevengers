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



    // Update is called once per frame
    void Update()
    {
        //Movementul de joystick
        if(Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
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
