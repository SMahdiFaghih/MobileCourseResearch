using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public int NumOfEnemies;

    void Awake()
    {
        Instance = this;
        NumOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
