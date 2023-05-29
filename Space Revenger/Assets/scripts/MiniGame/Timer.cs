using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float timeRemaining = timerMax;
    private const float timerMax = 20f;
    public Slider slider;
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateSliderValue();
        if (timeRemaining <= 0f)
        {
            LoadMainGame();
        }
        else if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }
        
    }

    float CalculateSliderValue()
    {
        return (timeRemaining / timerMax);
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
