using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    private TextMeshProUGUI distanceText;
    private Transform playerTransform;
    private Vector3 initialPosition;


    void Awake()
    {
        distanceText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        initialPosition = playerTransform.position;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerTransform.position, initialPosition);
        distanceText.text = " " + distance.ToString("F2") + "m";
    }
}
