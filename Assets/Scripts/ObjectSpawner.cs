using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabToSpawn;
    public float[] spawnDistance;
    public float[] deactivateDistance;
    private bool[] hasSpawned;
    private GameObject[] spawnedObjects;

    private PlayerDistance playerDistance;
    private Transform playerTransform;

    private void Start()
    {
        playerDistance = GetComponent<PlayerDistance>();
        playerTransform = GetComponent<Transform>();
        hasSpawned = new bool[prefabToSpawn.Length];
        spawnedObjects = new GameObject[prefabToSpawn.Length];
    }

   
  private void Update()
    {
        for (int i = 0; i < prefabToSpawn.Length; i++)
        {
            if (playerDistance.distance >= spawnDistance[i] && !hasSpawned[i])
            {
                Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 30 + new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));

                spawnedObjects[i] = Instantiate(prefabToSpawn[i], spawnPosition, Quaternion.identity);
                hasSpawned[i] = true;
            }

            if (playerDistance.distance >= deactivateDistance[i] && hasSpawned[i])
            {
                spawnedObjects[i].SetActive(false);
            }

            if (playerDistance.distance < deactivateDistance[i] && !hasSpawned[i])
            {
                hasSpawned[i] = false;
                spawnedObjects[i] = null;
            }
        }
    }

}