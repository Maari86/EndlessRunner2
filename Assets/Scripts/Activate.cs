using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject objectToSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}
