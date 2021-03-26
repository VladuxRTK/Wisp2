using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Scene sceneLoaded = SceneManager.GetActiveScene();
            SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
        }
    }
}
