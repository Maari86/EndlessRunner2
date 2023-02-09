using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDistance : MonoBehaviour
{
    Vector2 initialPosition;
    public float distance;
    public TMP_Text distanceText;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, initialPosition);
        distanceText.text = "Distance traveled: " + distance;
    }
}