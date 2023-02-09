using System.Collections;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public GameObject[] backgrounds; // List of all the backgrounds
    public float changeInterval = 100f; // Distance to change the background

    
    private int currentBackgroundIndex = 0;
    private float currentDistance = 0f;

    private void Update()
    {
        currentDistance += Time.deltaTime * changeInterval;

        // Check if it's time to change the background
        if (currentDistance >= changeInterval)
        {
            currentBackgroundIndex++;
            currentDistance = 0;

            // Set the next background
            if (currentBackgroundIndex >= backgrounds.Length)
            {
                currentBackgroundIndex = 0;
            }
            for (int i = 0; i < backgrounds.Length; i++)
            {
                if (i == currentBackgroundIndex)
                {
                    backgrounds[i].SetActive(true);
                }
                else
                {
                    backgrounds[i].SetActive(false);
                }
            }
        }
    }
}
