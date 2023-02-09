using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDistance = 100f;
    private bool hasSpawned = false;

    private PlayerDistance playerDistance;
    private Transform playerTransform;

    private void Start()
    {
        playerDistance = GetComponent<PlayerDistance>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerDistance.distance >= spawnDistance && !hasSpawned)
        {
            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 30;
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            hasSpawned = true;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}





