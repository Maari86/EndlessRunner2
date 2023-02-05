using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
  
    public string[] sceneNames;
    private int currentSceneIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {

        int nextSceneIndex = Random.Range(0, sceneNames.Length);
        while (nextSceneIndex == currentSceneIndex)
        {
            nextSceneIndex = Random.Range(0, sceneNames.Length);
        }

        SceneManager.LoadScene(sceneNames[nextSceneIndex]);
        currentSceneIndex = nextSceneIndex;
    }
}


