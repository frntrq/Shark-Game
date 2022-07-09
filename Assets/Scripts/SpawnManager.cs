using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {
        float startDelay1 = Random.Range(0.0f, 2.0f);
        float startDelay2 = Random.Range(0.0f, 2.0f);
        float repeatDelay1 = Random.Range(2.0f, 6.0f);
        float repeatDelay2 = Random.Range(2.0f, 7.0f);

        InvokeRepeating("SpawnEnemy", startDelay1, repeatDelay1);
        InvokeRepeating("SpawnPowerup", startDelay2, repeatDelay2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-16.0f, 16.0f);
        int randomIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(randomX, 0, 34);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-16.0f, 16.0f);
        Vector3 spawnPos = new Vector3(randomX, 0, 22);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
