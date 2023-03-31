using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn_Script : MonoBehaviour
{
    //refrence enemy
    [SerializeField] public GameObject[] enemy; 

    //spawn rate
    [SerializeField] private float spawn_rate = 1f;

    //check if enemy is spawned
    [SerializeField] private bool Is_Spawned = true;

    //0=N-V, 1=N-E, 2=N, 3=S 4=S-V, 5=S-E
    [SerializeField] public int spawn_side;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner(){

        WaitForSeconds wait = new WaitForSeconds(spawn_rate);

        while(Is_Spawned){
            yield return wait;
            
            spawn_side = Random.Range(0, 6);
            int rand = Random.Range(0, enemy.Length);
            GameObject enemyToSpawn = enemy[rand];
            if(spawn_side == 0)
                Instantiate(enemyToSpawn, new Vector3(-5f, Random.Range(2, 6f), 0), Quaternion.identity);
            if(spawn_side == 1)
                Instantiate(enemyToSpawn, new Vector3(5f, Random.Range(2, 6f), 0), Quaternion.identity);
            if(spawn_side == 2)
                Instantiate(enemyToSpawn, new Vector3(Random.Range(-5,5f), 7f, 0), Quaternion.identity);
            if(spawn_side == 3)
                Instantiate(enemyToSpawn, new Vector3(Random.Range(-5,5f), -7f, 0), Quaternion.identity);
            if(spawn_side == 4)
                Instantiate(enemyToSpawn, new Vector3(-5f, Random.Range(-6, 2f), 0), Quaternion.identity);
            if(spawn_side == 5)
                Instantiate(enemyToSpawn, new Vector3(5f, Random.Range(-6, 2f), 0), Quaternion.identity);
            
        }
    }
}
