using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject secondPrefabToSpawn;
    public GameObject thirdPrefabToSpawn;
    public GameObject fourthPrefabToSpawn;
    public float spawnDistance = 100f;
    public float deactivateDistance = 300f;

    private PlayerDistance playerDistance;
    private Transform playerTransform;
    private GameObject spawnedPrefab;

    private void Start()
    {
        playerDistance = GetComponent<PlayerDistance>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerDistance.distance >= spawnDistance)
        {
            Vector3 spawnPosition = playerTransform.position + playerTransform.forward * 30;
            GameObject[] prefabs = { prefabToSpawn, secondPrefabToSpawn, thirdPrefabToSpawn, fourthPrefabToSpawn };
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject randomPrefab = prefabs[randomIndex];
            
            spawnedPrefab = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
            spawnDistance += 200f;
        }

        if (spawnedPrefab != null)
        {
            float distanceFromPlayer = Vector3.Distance(playerTransform.position, spawnedPrefab.transform.position);
            
            if (distanceFromPlayer >= deactivateDistance)
            {
                spawnedPrefab.SetActive(false);
                
            }
        }
    }
}









