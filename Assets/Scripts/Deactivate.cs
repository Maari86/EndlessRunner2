using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject objectToDeactivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objectToDeactivate.SetActive(false);
        }
    }
}

