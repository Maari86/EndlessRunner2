using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject spawning;
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", spawnTime, spawnDelay);
    }
    public void Spawner()
    {
        Instantiate(spawning, transform.position, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("Spawner");
        }

    }

   
}
