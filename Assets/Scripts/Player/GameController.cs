using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int collectible = 0;

    public bool collectedAll = false;
    void Start()
    {
        
    }
    private void Update()
    {
        if (collectible <= 0)
        {
            collectedAll = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else collectedAll = false;
    }
    
}
