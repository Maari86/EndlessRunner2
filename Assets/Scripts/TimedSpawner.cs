using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject spawning;
    public bool stopSpawning;
    public float spawnTime;
    public float spawnDelay;
    public float destroyTime;
    private int objectCount = 0;

    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", spawnTime, spawnDelay);
    }
    public void Spawner()
    {
        spawnedObject = Instantiate(spawning, transform.position, transform.rotation);
        spawnedObject.name = "SpawnedObject_" + objectCount;
        objectCount++;
        Invoke("DeactivateObject", destroyTime);
        if (stopSpawning)
        {
            CancelInvoke("Spawner");
        }
    }

    private void DeactivateObject()
    {
        if (spawnedObject != null)
        {
         
            Destroy(spawnedObject);
        }
            
    }

}
