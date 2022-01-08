using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gameObjects;
    private float TimerBTSpawn;
    public float StartTimerBtWSpawnl;
    public float decrezeTime;
    public float minTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (TimerBTSpawn <= 0)
        {
            int rand = Random.Range(0, gameObjects.Length);
            float random = Random.Range(-2.8f, 2.46f);
            Instantiate(gameObjects[rand], new Vector2(random, 5), Quaternion.identity);
            TimerBTSpawn = StartTimerBtWSpawnl;
            if (StartTimerBtWSpawnl > minTime)
            {
                StartTimerBtWSpawnl -= decrezeTime;
            }
        }
        else
            TimerBTSpawn -= Time.deltaTime;
    }
}
