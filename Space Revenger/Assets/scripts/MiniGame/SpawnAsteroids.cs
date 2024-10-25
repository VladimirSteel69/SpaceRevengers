using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] public GameObject[] asteroidPrefab;

    

    public Transform player;

    public float respawnTime = 1f;

    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(astroidWave());
    }

    private void spawnAsteroids()
    {
        int rand = Random.Range(0, asteroidPrefab.Length);
        GameObject a = Instantiate(asteroidPrefab[rand]) as GameObject;
        a.transform.position = new Vector2(player.position.x, screenBounds.y * 1.3f);
    }

    IEnumerator astroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroids();
        }
    }
}
