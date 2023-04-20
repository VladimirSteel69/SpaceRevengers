using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToMainGame : MonoBehaviour
{

    
    public Animator transition;


   
    public void LoadMainGame(){
        StartCoroutine(LoadMainLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadMainLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(1);
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
